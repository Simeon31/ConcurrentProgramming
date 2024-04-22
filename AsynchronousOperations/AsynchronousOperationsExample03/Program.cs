using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousOperationsExample03
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fileName = "test.txt";
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var buffer = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 114, 108, 100, 33 };
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }
            Console.WriteLine("Succesful record in file: " +  fileName);
        }
    }
}
