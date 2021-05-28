using Microsoft.AspNetCore.Mvc;
using SBF.Domain.Entity;
using SBF.Domain.Interfaces.Services;
using WebAPI.Contracts.Request;
using System;
using WebAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;
        private readonly IMoedaService _moedaService;
        private readonly ICurrencyConverterService _currencyConverterService;

        public ProdutoController(IProdutoService produtoService,
            IMoedaService moedaService,
            ICurrencyConverterService currencyConverterService
            )
        {
            _produtoService = produtoService;
            _moedaService = moedaService;
            _currencyConverterService = currencyConverterService;

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var produto = _produtoService.Get(id);
            return Ok(ToViewModel(produto));
        }

        private async Task<ProdutosListagemViewModel> ToViewModel(Produto produto)
        {
            List<PrecoEmOutrasMoedasViewModel> listaPrecosEmOutrasMoedas = new List<PrecoEmOutrasMoedasViewModel>();
            var moedas = _moedaService.Listar();
            foreach (var item in moedas)
            {
                listaPrecosEmOutrasMoedas.Add(new PrecoEmOutrasMoedasViewModel { Moeda = item.Sigla, Preco = await GetValorProdutoMoeda(item.Sigla, produto.Preco) });
            }
            
            return new ProdutosListagemViewModel
            {
                Descricao = produto.Descricao,
                PrecoEmReal = produto.Preco,
                PrecosEmOutrasMoedas = listaPrecosEmOutrasMoedas.ToArray()
            };
        }

        private async Task<double> GetValorProdutoMoeda(string sigla, double preco)
        {
            return preco * _currencyConverterService.GetCurrencyValue(sigla);           
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoCadastroPostRequest request)
        {
            if (request == null)
                return BadRequest("Produto não encontrado.");

            Produto produto = new Produto();
            produto.Descricao = request.Descricao;
            produto.Preco = request.Preco;

            _produtoService.Add(produto);

            return Ok("Cadastro inserido com sucesso.");

        }

        [HttpPut]
        public IActionResult Put([FromBody] ProdutoCadastroPutRequest request)
        {
            if (request == null)
                return BadRequest("Produto não encontrado");

            var produto = _produtoService.Get(request.Id);
            produto.Descricao = request.Descricao;
            produto.Preco = request.Preco;
            _produtoService.Update(produto);

            return Ok("Cadastro alterado com sucesso.");
        }       
    }
}
