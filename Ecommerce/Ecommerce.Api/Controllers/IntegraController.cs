using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ecommerce.Integration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Api.Controllers
{
#if DEBUG 
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IntegraController'
    public class IntegraController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IntegraController'
    {
        private readonly IHttpClientFactory _httpClientFactory;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IntegraController.IntegraController(IHttpClientFactory)'
        public IntegraController(IHttpClientFactory httpClientFactory)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IntegraController.IntegraController(IHttpClientFactory)'
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("/api/activity/")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IntegraController.GetRandomActivity()'
        public async Task<Board> GetRandomActivity()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IntegraController.GetRandomActivity()'
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetStringAsync("http://www.boredapi.com/api/activity/");

            return JsonConvert.DeserializeObject<Board>(response);
        }

    }
#endif
}