using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(IConfiguration config) : base(config)
        {
        }
         
    }
}
