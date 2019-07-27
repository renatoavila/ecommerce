using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service.Interface
{
    public interface IClientServices
    {
        Client GetClient(Guid key);
        Guid ChangeClient(Client client);
    }
}