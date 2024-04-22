using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousOperationsExample06
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting an asynchronous operation");

            var result = await ComputeResultAsync(10, 20);

            Console.WriteLine("Result: " + result);
        }

        private static async Task<int> ComputeResultAsync(int v1, int v2)
        {
            Console.WriteLine($"The start of the asynchronous operation: {v1} + {v2}");

            var tsc = new TaskCompletionSource<int>();

            await Task.Delay(3000);

            int result = v1 + v2;

            tsc.SetResult(result);

            Console.WriteLine($"The end of the asynchronous operation: {v1} + {v2}");

            return await tsc.Task;
        }
    }
}
