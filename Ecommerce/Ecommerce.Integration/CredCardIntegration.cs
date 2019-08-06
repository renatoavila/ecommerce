using Ecommerce.Integration.Inferface;
using Ecommerce.Integration.Model;
using Ecommerce.Integration.Util;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        public CredCardIntegration(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }
        public ResponseCreditCardTransaction Execute(RequestCreditCardTransation requestCreditCardTransation)
        {
            ProxyHttp<ResponseCreditCardTransaction> http
            = new ProxyHttp<ResponseCreditCardTransaction>(_httpClientFactory, _config);
            Task<ResponseCreditCardTransaction> response = http.Post("api/v1/CreditCardTransaction", requestCreditCardTransation);

            return response.Result;
        }
    }
}
