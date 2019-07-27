using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using Flunt.Validations;
using System;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class ClientServices : IClientServices
    {
        private readonly IClientBusiness _clientBusiness;


        public ClientServices(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        public Guid ChangeClient(Client client)
        {
            client.AddNotifications(new Flunt.Validations.Contract()
              .Requires()
              .IsTrue(_clientBusiness.CPFValidate(client), "CPF", "Errado")
           );

            if (client.Valid)
            {
                _clientBusiness.ChangeClient(client);
            }

            return client.Key;
        }

        public Client GetClient(Guid key)
        {
            return _clientBusiness.GetClient(key);
        }
    }
}
