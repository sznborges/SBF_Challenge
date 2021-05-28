using SBF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Produto Get(int id);
        void Add(Produto produto);
        void Update(Produto produto);  
    }
}
