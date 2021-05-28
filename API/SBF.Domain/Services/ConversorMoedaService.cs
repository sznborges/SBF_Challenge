using System;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Linq;
using System.Threading.Tasks;
using SBF.Domain.Interfaces.Services;
using SBF.Domain.Services.Response;
using System.Dynamic;
using System.Collections.Generic;


namespace SBF.Domain.Services
{
    public class ConversorMoedaService : IConversorMoedaService
    {
        private readonly IFlurlClient _flurlClient;
        private const string _URL = "https://free.currconv.com/api/v7/convert?";
        private const string _KEY = "ade612e74c082d0005d4";

        public ConversorMoedaService(IFlurlClientFactory flurlClientFac)
        {
            this._flurlClient = flurlClientFac.Get(_URL);
        }
        public double GetConversorMoeda(string de, string para)
        {

            return Converter(de, para).Result;
        }

        private async Task<double> Converter(string de, string para)
        {
            var retorno = await _flurlClient
                         .Request()
                         .SetQueryParams(new { apiKey = _KEY, compact = "ultra", q = de + "_" + para })
                         .GetAsync()
                         .ReceiveJson();

            double valor = 0;
            foreach (var item in retorno)
            {
                valor = item.Value;
            }
            return valor;
        }

    }
}

