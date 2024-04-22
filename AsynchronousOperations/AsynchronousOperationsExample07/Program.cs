using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace AsynchronousOperationsExample07
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            List<string> coins = new List<string> { "bitcoin", "ethereum", "dogecoin" };

            var url = $"https://api.coingecko.com/api/v3/simple/price?ids={string.Join(",", coins)}&vs_currencies=usd";

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, decimal>>>(content);

            foreach (var coin in coins)
            {
                Console.WriteLine($"{coin}: {result[coin]["usd"]}$");
            }
        }
    }
}
