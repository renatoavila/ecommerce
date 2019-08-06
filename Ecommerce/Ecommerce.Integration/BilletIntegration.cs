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
    public class BilletIntegration : IBilletIntegration
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        public BilletIntegration(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }
        public ResponsePaymentSlipTransation Execute(RequestPaymentSlipTransaction requestPaymentSlipTransaction)
        {
            ProxyHttp<ResponsePaymentSlipTransation> http
             = new ProxyHttp<ResponsePaymentSlipTransation>(_httpClientFactory, _config);
            Task<ResponsePaymentSlipTransation> response = http.Post("api/v1/PaymentSlipTransaction", requestPaymentSlipTransaction);

            return response.Result;
        }
    }
}
