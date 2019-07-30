using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;


namespace Ecommerce.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IConfiguration config) : base(config)
        {
        }

    }
}
