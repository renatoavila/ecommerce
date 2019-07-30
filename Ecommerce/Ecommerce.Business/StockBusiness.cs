using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public class StockBusiness: IStockBusiness

    {

        private readonly IStockRepository _stockRepository;
        public StockBusiness(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public int ChangeStock(ItemCart item, Operation operation)
        {
            return ChangeStock(item.product, item.Amount, operation);
          
        }
        public int ChangeStock(Product product, int amount, Operation operation)
        {
            switch (operation)
            {
                case Operation.Increment:
                    break;
                case Operation.Decrement:
                    break;

            }
            return 0;
        }

    }
}
