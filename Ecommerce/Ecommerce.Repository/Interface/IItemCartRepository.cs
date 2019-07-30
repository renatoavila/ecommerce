using Ecommerce.Domain.Entity;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interface
{
    public interface IItemCartRepository : IRepository<ItemCart>
    {
        IEnumerable<ItemCart> GetAll(long shopCartId);
    }
}
