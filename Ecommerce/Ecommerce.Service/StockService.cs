using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class StockService : IStockServices
    {
        private readonly IStockBusiness _stockBusiness;

        public StockService(IStockBusiness stockBusiness)
        {
            _stockBusiness = stockBusiness;
        }

        public int ChangeStock(Product product, int amount, Operation operation)
        {
            return 0;
           //return _stockBusiness.ChangeStock(product, amount, Operation.Increment);
        }
    }
}
