using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutoServices(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }
        public List<Produto> List()
        {
            return _produtoBusiness.GetAll();
        }
         

        public long Insert(Produto Produto)
        {
            return _produtoBusiness.Insert(Produto);
        }
    }
}
