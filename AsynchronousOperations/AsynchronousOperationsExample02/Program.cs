using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousOperationsExample02
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://www.example.com");
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
