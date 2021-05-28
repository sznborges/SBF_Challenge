using Flurl.Http;
using Flurl.Http.Configuration;
using SBF.Domain.Interfaces.Services;
using System.Threading.Tasks;


namespace SBF.Domain.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private readonly IFlurlClient _flurlClient;
        private const string _URL = "https://free.currconv.com/api/v7/convert?";
        private const string _KEY = "ade612e74c082d0005d4";
        private const string _ORIGIN = "BRL";

        public CurrencyConverterService(IFlurlClientFactory flurlClientFac)
        {
            this._flurlClient = flurlClientFac.Get(_URL);
        }
        public double GetCurrencyValue(string targetCurrencyAbbreviation)
        {
            return Convert(targetCurrencyAbbreviation).Result;
        }

        private async Task<double> Convert(string targetCurrencyAbbreviation)
        {
            var retorno = await _flurlClient
                         .Request()
                         .SetQueryParams(new { apiKey = _KEY, compact = "ultra", q = _ORIGIN + "_" + targetCurrencyAbbreviation })
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

