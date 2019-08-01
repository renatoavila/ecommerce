using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ecommerce.Integration.Model;
using Ecommerce.Integration.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
       private readonly IHttpClientFactory _httpClientFactory;
        public TestApiController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public ActionResult<RequestCreditCardTransation> Get()
        { 
            ProxyHttp<RequestCreditCardTransation> http
                = new ProxyHttp<RequestCreditCardTransation>(_httpClientFactory);
            Task<RequestCreditCardTransation> o = http.Post("api/v1/CreditCardTransaction", new ResponseCreditCardTransaction());

            return o.Result;
        }

    }
}