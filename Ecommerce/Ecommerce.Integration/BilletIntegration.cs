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
    public class BilletIntegration : IBilletIntegration
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BilletIntegration(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public ResponsePaymentSlipTransation Execute(RequestPaymentSlipTransaction requestPaymentSlipTransaction)
        {
            ProxyHttp<ResponsePaymentSlipTransation> http
             = new ProxyHttp<ResponsePaymentSlipTransation>(_httpClientFactory);
            Task<ResponsePaymentSlipTransation> response = http.Post("api/v1/PaymentSlipTransaction", requestPaymentSlipTransaction);

            return response.Result;
        }
    }
}
