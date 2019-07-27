using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Api.Model
{
    public class AddressModel
    {
        public Guid? Key { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }
}
