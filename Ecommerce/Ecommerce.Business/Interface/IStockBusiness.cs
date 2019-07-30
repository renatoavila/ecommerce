using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IStockBusiness

    {/// <summary>
     /// 
     /// </summary>
     /// <param name="item"></param>
     /// <param name="operation"></param>
     /// <returns></returns>
        int ChangeStock(ItemCart item, Operation operation);
        int ChangeStock(Product product, int amount, Operation operation);

    }
}
