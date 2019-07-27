using System;
using System.Collections.Generic; 
using System.Text;
using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Entity.Base;

namespace Ecommerce.Domain.Entity
{

    [Table("Client")]
    public class Client : Base.Entity
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        [Write(false)]
        public Address Address { get; set; }
        public long AddressId { get; set; }




    }
}
