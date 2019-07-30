using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace NetCoreHttpClient
{
    class Program
    {
        private const string listaPaisesUrl = "http://services.groupkt.com/country/get/all";
        private const string paisesUrl = "https://viacep.com.br/ws/01001000/json/";
        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await GetDadosWebServiceAsync();
            }).GetAwaiter().GetResult();
            Console.ReadLine();
        }
        public static async Task GetDadosWebServiceAsync()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(paisesUrl);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Status Code do Response : {(int)response.StatusCode} {response.ReasonPhrase}");
                string responseBodyAsText = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Recebidos payload de {responseBodyAsText.Length} caracteres");
                Console.WriteLine();
                Console.WriteLine(responseBodyAsText);
            }
        }
    }
}
