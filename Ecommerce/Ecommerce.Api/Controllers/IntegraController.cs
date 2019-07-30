using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegraController : ControllerBase
    {
            private readonly IHttpClientFactory _httpClientFactory;

            public IntegraController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            [HttpGet]
            [Route("/api/activity/")]
            public async Task<Board> GetRandomActivity()
            {
                var client = _httpClientFactory.CreateClient();

                var response = await client.GetStringAsync("http://www.boredapi.com/api/activity/");
         
                return JsonConvert.DeserializeObject<Board>(response);
        }
      
    }
}