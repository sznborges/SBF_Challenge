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

        [JsonProperty("PrecoReal")]
        public double PrecoReal { get; set; }

        [JsonProperty("PrecoOutrasMoedas")]
        public PrecoOutrasMoedasViewModel[] PrecoOutrasMoedas { get; set; }
    }
}
