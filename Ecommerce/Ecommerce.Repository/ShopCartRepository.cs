using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Ecommerce.Repository
{
    public class ShopCartRepository : Repository<ShopCart>, IShopCartRepository
    {
        private readonly IRepository<ShopCart> _shopcartRepository;

        public ShopCartRepository(IConfiguration config,
                                 IRepository<ShopCart> shopcartRepository) : base(config)
        {
            _shopcartRepository = shopcartRepository;
        }

    }
}
