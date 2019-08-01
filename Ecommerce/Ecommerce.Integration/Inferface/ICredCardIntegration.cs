using Ecommerce.Integration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.Inferface
{
    public interface ICredCardIntegration
    {
        ResponseCreditCardTransaction Execute(RequestCreditCardTransation requestCreditCardTransation);
    }
}
