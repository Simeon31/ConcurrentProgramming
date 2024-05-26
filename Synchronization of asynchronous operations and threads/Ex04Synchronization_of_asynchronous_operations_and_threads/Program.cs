using System;
using System.Threading.Tasks;

namespace Ex04Synchronization_of_asynchronous_operations_and_threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() => CalculateSum(10)); // starting the asynchronous operation
            Console.WriteLine("Waiting for the result...");

            int result = task.GetAwaiter().GetResult(); // waiting for the operaton to complete and getting the result

            Console.WriteLine("Result: " + result);

            Console.ReadLine();
        }

        private static int CalculateSum(int n)
        {
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
