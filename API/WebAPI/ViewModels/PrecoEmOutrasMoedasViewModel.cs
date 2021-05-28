using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class PrecoEmOutrasMoedasViewModel
    {
        [JsonProperty("Moeda")]
        public string Moeda { get; set; }

        [JsonProperty("Preco")]
        public double Preco { get; set; }
    }
}
