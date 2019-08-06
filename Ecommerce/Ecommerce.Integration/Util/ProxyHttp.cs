using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Integration.Util
{
    public class ProxyHttp<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public ProxyHttp(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<T> Post(string metodo, Object obj)
        {
            string url = _config.GetSection("Url").GetSection("authorization").Value + metodo;
            string jsonInString = JsonConvert.SerializeObject(obj);
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync(url,
                                                    new StringContent(jsonInString,
                                                                        Encoding.UTF8,
                                                                        "application/json"));
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
