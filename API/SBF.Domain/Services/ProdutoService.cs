using SBF.Domain.Entity;
using SBF.Domain.Exceptions;
using SBF.Domain.Interfaces.Repository;
using SBF.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public void Add(Produto produto)
        {
            _produtoRepository.Add(produto);
            _produtoRepository.SaveChanges();
        }

        public void Update(Produto produto)
        {
            if (produto == null)
                throw new ProdutoNaoEncontradoException();

            var produtoDb = this._produtoRepository.GetById(produto.Id);
            if (produtoDb == null)
                throw new ProdutoNaoEncontradoException();

            produtoDb.Descricao = produto.Descricao;
            produto.Preco = produto.Preco;

            _produtoRepository.Update(produtoDb);
            _produtoRepository.SaveChanges();
        }
    }
}
