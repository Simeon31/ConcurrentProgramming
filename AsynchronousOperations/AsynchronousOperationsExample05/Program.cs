using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousOperationsExample05
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting an asynchronous operation");

            var result = await Task.Run(() => ComputeResult(10, 20));

            Console.WriteLine($"The result of the operation is: {result}");
        }

        private static int ComputeResult(int a, int b)
        {
            Console.WriteLine($"Starting the calculation: {a + b}");
            Task.Delay(3000).Wait();

            Console.WriteLine($"End of the calculation: {a + b}");

            return a + b;
        }
    }
}
