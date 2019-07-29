using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IShotCartBusiness
    {
        List<ItemCart> ListProducts();
        void AddItem(ItemCart item);
        void RemoveItem(int indice);
        void ClearItems();
        ItemCart Item(int indice);
        int ItemsCount();
        double PesoTotal();
        decimal PrecoTotal();
    }
}
