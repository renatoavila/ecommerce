using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Business
{
   public class ShopCart: IShotCartBusiness
    {
        private Guid _GuidClient;
        private DateTime _DataHora;
        private List<ItemCart> ListProduct;
        public ShopCart(Guid guidclient)
        {
            ListProduct = new List<ItemCart>();
            _GuidClient = guidclient;
            _DataHora = DateTime.Now;
        }
        public List<ItemCart> ListProducts()
        {
           return ListProduct;
        }
        public void AddItem(ItemCart item)
        {
            ListProduct.Add(item);
        }
        public void RemoveItem(int indice)
        {
           ListProduct.RemoveAt(indice);
        }
        public void ClearItems()
        {
            ListProduct.Clear();
        }
        public ItemCart Item(int indice)
        {
            return (ItemCart)(ListProduct[indice]);
        }
        public int ItemsCount()
        {
            return ListProduct.Count;
        }
        public double PesoTotal()
        {
            double result = 0;
            Product product;
            for (int i = 0; i < ListProduct.Count; i++)
            {
               product = ((ItemCart)(ListProduct[i])).product;
               result += product.Weight;
           }
            return result;
        }
        public decimal PrecoTotal()
        {
            decimal result = 0;
            Product product;
            for (int i = 0; i < ListProduct.Count; i++)
            {
                product = ((ItemCart)(ListProduct[i])).product;
                result += product.CostPrice ;
            }
            return result;
        }
    }
}
