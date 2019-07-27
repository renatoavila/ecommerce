using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity
{

    public class Client : Base.Entity
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
