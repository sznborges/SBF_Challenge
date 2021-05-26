using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
