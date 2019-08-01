using Ecommerce.Domain.Entity;
 
namespace Ecommerce.Repository.Interface
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock GetByProduct(long productId);
    }
}
