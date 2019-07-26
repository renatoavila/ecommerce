using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Interface;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Ecommerce.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoBusiness(IProdutoRepository ProdutoRepository)
        {
            _produtoRepository = ProdutoRepository;
        }

        public long Insert(Produto Produto)
        {
            return _produtoRepository.Insert(Produto);
        }

        public List<Produto> GetAll()
        {
            return _produtoRepository.GetAll().ToList();
        }

    }
}
