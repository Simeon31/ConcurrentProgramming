using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousOperationsExample04
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting asynchronous operations");

            var task1 = Task.Delay(3000);
            var task2 = Task.Delay(2000);
            var task3 = Task.Delay(1000);

            await Task.WhenAll(task1, task2, task3); // Waiting until the completion of all tasks

            Console.WriteLine("End of asynchronous operation");

        }
    }
}
