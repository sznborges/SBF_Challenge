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
    public class ConsultaPrecoController : ControllerBase
    {
        private readonly IMoedaService _moedaService;
        private readonly ICurrencyConverterService _currencyConverterService;

        public ConsultaPrecoController(
            IMoedaService moedaService,
            ICurrencyConverterService currencyConverterService
            )
        {
            _moedaService = moedaService;
            _currencyConverterService = currencyConverterService;

        }

        [HttpGet]
        public IActionResult Get(double preco)
        {
            return Ok(ToViewModel(preco));
        }

        private async Task<IList<PrecoEmOutrasMoedasViewModel>> ToViewModel(double precoOriginal)
        {
            List<PrecoEmOutrasMoedasViewModel> listaPrecosEmOutrasMoedas = new List<PrecoEmOutrasMoedasViewModel>();
            var moedas = _moedaService.Listar();
            foreach (var item in moedas)
            {
                listaPrecosEmOutrasMoedas.Add(new PrecoEmOutrasMoedasViewModel { Moeda = item.Sigla?.Trim(), Preco = await GetValorProdutoMoeda(item.Sigla, precoOriginal) });
            }

            return listaPrecosEmOutrasMoedas;
            
        }

        private async Task<double> GetValorProdutoMoeda(string sigla, double preco)
        {
            return preco * _currencyConverterService.GetCurrencyValue(sigla);           
        }
  
    }
}
