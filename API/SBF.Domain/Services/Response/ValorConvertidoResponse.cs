using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Services.Response
{
    public class ValorConvertidoResponse
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
