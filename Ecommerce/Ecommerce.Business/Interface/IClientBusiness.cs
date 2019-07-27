using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IClientBusiness
    {
        Client GetClient(Guid key);

        Guid ChangeClient(Client client);

        bool CPFValidate(Client client);
    }
}
