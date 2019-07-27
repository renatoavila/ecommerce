using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Api.Model
{
    public class AddressModel
    {
        public string Street { get; set; }
        public string number { get; set; }

        public string neighborhood { get; set; }

        public string City { get; set; }

        public string state { get; set; }

    }
}
