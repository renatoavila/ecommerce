using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    public class Product : Base.Entity
    {
        public decimal  CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public  int UptadedStock { get; set; }
    }
}
