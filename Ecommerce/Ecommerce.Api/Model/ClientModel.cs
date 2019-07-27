using System;

namespace Ecommerce.Api.Model
{

    public class ClientModel  
    {
        public Guid? Key { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
    }
}
