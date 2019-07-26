using Ecommerce.Domain.Entity;
using System.Collections.Generic;

namespace Ecommerce.Business.Interface
{
    public interface IProdutoBusiness
    {
        long Insert(Produto Produto);

        List<Produto> GetAll();
    }
}