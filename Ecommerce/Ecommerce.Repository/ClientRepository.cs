using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;

namespace Ecommerce.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly IAddressRepository _addressRepository;

        public ClientRepository(IConfiguration config,
                                IAddressRepository addressRepository) : base(config)
        {
            _addressRepository = addressRepository;
        }

        public override long Insert(Client client)
        {
            client.AddressId = _addressRepository.Insert(client.Address);
            return base.Insert(client);
        }

        public override bool Update(Client client)
        {
            client.Address.Id = _addressRepository.Get(client.Address.Key)?.Id ?? 0;
            client.AddressId = client.Address.Id;
            _addressRepository.Update(client.Address);
            client.Id = base.Get(client.Key)?.Id ?? 0;
            return base.Update(client);
        }

        public override Client Get(Guid key)
        {
            var client = base.Get(key);
            client.Address = _addressRepository.Get(client.AddressId);
            return client;
        }
    }
}
