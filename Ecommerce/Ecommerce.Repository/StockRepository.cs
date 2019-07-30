using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;


namespace Ecommerce.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(IConfiguration config) : base(config)
        {
        }

    }
}
