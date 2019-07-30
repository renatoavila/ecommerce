using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;


namespace Ecommerce.Repository
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(IConfiguration config) : base(config)
        {
        }

    }
}
