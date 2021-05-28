using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class ProdutosListagemViewModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Descricao")]
        public string Descricao { get; set; }

        [JsonProperty("PrecoEmReal")]
        public double PrecoEmReal { get; set; }

        [JsonProperty("PrecoEmOutrasMoedas")]
        public PrecoEmOutrasMoedasViewModel[] PrecosEmOutrasMoedas { get; set; }
    }
}
