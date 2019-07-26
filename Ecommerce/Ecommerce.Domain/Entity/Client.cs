using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity
{

    public class Client: Base.Entity
    {
        string CPF { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        Address Address { get; set; }
    }
}
