using Ecommerce.Integration.Inferface;
using Ecommerce.Integration.Model;
using Ecommerce.Integration.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration
{
    public class CredCardIntegration : ICredCardIntegration
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CredCardIntegration(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public ResponseCreditCardTransaction Execute(RequestCreditCardTransation requestCreditCardTransation)
        {
            ProxyHttp<ResponseCreditCardTransaction> http
            = new ProxyHttp<ResponseCreditCardTransaction>(_httpClientFactory);
            Task<ResponseCreditCardTransaction> response = http.Post("api/v1/CreditCardTransaction", requestPaymentSlipTransaction);

            return response.Result;
        }
    }
}
