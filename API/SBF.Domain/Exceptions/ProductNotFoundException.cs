using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Produto não encontrado")
        {

        }
    }
}
