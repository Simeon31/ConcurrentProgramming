using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousOperations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("starting asynchronous operation");
            await Task.Delay(3000); // A task that will complete after the time delay
            Console.WriteLine("End of asynchronous operation");
        }
    }
}
