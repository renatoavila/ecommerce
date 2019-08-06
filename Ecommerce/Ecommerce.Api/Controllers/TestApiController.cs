using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ecommerce.Integration.Model;
using Ecommerce.Integration.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TestApiController'
    public class TestApiController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TestApiController'
    {
       private readonly IHttpClientFactory _httpClientFactory; 
       private readonly IConfiguration _config;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TestApiController.TestApiController(IHttpClientFactory, IConfiguration)'
        public TestApiController(IHttpClientFactory httpClientFactory, IConfiguration config)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TestApiController.TestApiController(IHttpClientFactory, IConfiguration)'
        {

            _httpClientFactory = httpClientFactory;
            _config = config;
        }
        [HttpGet]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TestApiController.Get()'
        public ActionResult<RequestCreditCardTransation> Get()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TestApiController.Get()'
        { 
            ProxyHttp<RequestCreditCardTransation> http
                = new ProxyHttp<RequestCreditCardTransation>(_httpClientFactory, _config);
            Task<RequestCreditCardTransation> o = http.Post("api/v1/CreditCardTransaction", new ResponseCreditCardTransaction());

            return o.Result;
        }

    }
}