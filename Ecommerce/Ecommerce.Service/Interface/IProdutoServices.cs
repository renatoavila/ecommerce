using Ecommerce.Domain.Entity;
using System.Collections.Generic;

namespace Ecommerce.Service.Interface
{
    public interface IProdutoServices
    {
        List<Produto> List();
        long Insert(Produto Produto);
    }
}