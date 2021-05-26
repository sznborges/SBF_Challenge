using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Exceptions
{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException() : base("Produto não encontrado")
        {

        }
    }
}
