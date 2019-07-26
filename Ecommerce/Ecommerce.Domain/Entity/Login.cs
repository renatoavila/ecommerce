using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    public class Login: Base.Entity
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
