using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class ProdutoCadastroViewModel
    {
        [JsonProperty("Id")]
        public int MotoristaId { get; set; }

        [JsonProperty("Descricao")]
        public string Descricao { get; set; }

        [JsonProperty("Preco")]
        public decimal Preco { get; set; }
    }
}
