using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Util
{
    public class ProxyHttp<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public ProxyHttp(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> Post(string metodo, Object obj)
        {
            string url = "http://authorization-api.ddns.net:5000/" + metodo;
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
