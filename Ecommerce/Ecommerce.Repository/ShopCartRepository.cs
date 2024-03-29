﻿using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Ecommerce.Repository
{
    public class ShopCartRepository : Repository<ShopCart>, IShopCartRepository
    {
        public ShopCartRepository(IConfiguration config) : base(config)
        {
        }

    }
}
