using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Services.Response
{
    public class ConverteMoedaResponse
    {
        [JsonProperty("results")]
        public ValorConvertidoResponse[] Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
