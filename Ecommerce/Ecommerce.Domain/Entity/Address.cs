using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    [Table("Address")]
    public class Address : Base.Entity
    {
        public string Street { get; set; }
        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }
}
