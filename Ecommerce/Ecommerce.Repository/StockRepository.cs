using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Ecommerce.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(IConfiguration config) : base(config)
        {
        }

        public Stock GetByProduct(long productId)
        {
            return base.GetAll().Where(x => x.productId == productId).FirstOrDefault();
        }
    }
}
