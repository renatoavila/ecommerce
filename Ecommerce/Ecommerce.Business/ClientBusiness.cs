using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class ClientBusiness : IClientBusiness
    {

        private readonly IClientRepository _clientRepository;
        public ClientBusiness(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Guid ChangeClient(Client client)
        {
            //if (!_clientRepository.Update(client))
                 _clientRepository.Insert(client);
           
            return client.Key;
        }

        public bool CPFValidate(Client client)
        {
            //todo: implementar validador de CPF
            return false;
        }

        public Client GetClient(Guid key)
        {
            return _clientRepository.Get(key);
        }
    }
}
