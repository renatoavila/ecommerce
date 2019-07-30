using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Ecommerce.Repository
{
    public class ItemCartRepository : Repository<ItemCart>, IItemCartRepository
    {
        IProductRepository _productRepository;

        public ItemCartRepository(IConfiguration config,
                                  IProductRepository productRepository) : base(config)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ItemCart> GetAll(long shopCartId)
        {
            List<ItemCart> ret = base.GetAll().Where(x => x.shopCartId == shopCartId).ToList();
            foreach (var item in ret)
            {
                item.product = _productRepository.Get(item.productId);
            }
            return ret;
        }


        public override long Insert(ItemCart itemCart)
        {
            itemCart.productId = _productRepository.Get(itemCart.product.Key)?.Id ?? 0;
            return base.Insert(itemCart);
        }

    }
}
