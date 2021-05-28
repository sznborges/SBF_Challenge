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
        private readonly IConversorMoedaService _conversorMoedaService;

        public ProdutoController(IProdutoService produtoService,
            IConversorMoedaService conversorMoedaService
            )
        {
            _produtoService = produtoService;
            _conversorMoedaService = conversorMoedaService;

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var produto = _produtoService.Get(id);
            return Ok(ToViewModel(produto));
        }

        private async Task<ProdutosListagemViewModel> ToViewModel(Produto produto)
        {
            List<PrecoOutrasMoedasViewModel> precosOutrasMoedas = new List<PrecoOutrasMoedasViewModel>();
            precosOutrasMoedas.Add(new PrecoOutrasMoedasViewModel { Moeda = "EUR", Preco = await ConverterValor(EnumMoeda.EUR, produto.Preco) });
            precosOutrasMoedas.Add(new PrecoOutrasMoedasViewModel { Moeda = "USD", Preco = await ConverterValor(EnumMoeda.USD, produto.Preco) });
            precosOutrasMoedas.Add(new PrecoOutrasMoedasViewModel { Moeda = "INR", Preco = await ConverterValor(EnumMoeda.INR, produto.Preco) });



            return new ProdutosListagemViewModel
            {
                Descricao = produto.Descricao,
                PrecoReal = produto.Preco,
                PrecoOutrasMoedas = precosOutrasMoedas.ToArray()
            };
        }

        private async Task<double> ConverterValor(EnumMoeda moeda, double preco)
        {
            switch (moeda)
            {
                case EnumMoeda.USD:
                    return preco * _conversorMoedaService.GetConversorMoeda("BRL", "USD");
                case EnumMoeda.EUR:
                    return preco * _conversorMoedaService.GetConversorMoeda("BRL", "EUR");
                // return await 
                case EnumMoeda.INR:
                  return preco *  _conversorMoedaService.GetConversorMoeda("BRL", "INR");
                default:
                    return 0;
            }
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

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
