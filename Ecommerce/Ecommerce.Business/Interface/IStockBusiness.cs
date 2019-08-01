using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IStockBusiness
    {
        void StockKepping(Product product, int AmountStock);

        void PaymentStock(ItemCart item);

        void PaymentStock(Product product, int amount);

        bool ReservedStock(ItemCart item);

        bool ReservedStock(Product product, int amount);

        void ReverseStock(ItemCart item);

        void ReverseStock(Product product, int amount); 
}
}
