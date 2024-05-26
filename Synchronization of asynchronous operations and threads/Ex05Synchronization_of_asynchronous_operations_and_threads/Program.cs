using System;
using System.Threading;

namespace Ex05Synchronization_of_asynchronous_operations_and_threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting anasynchronous operation...");

            ThreadPool.QueueUserWorkItem(DoWork);

            Console.WriteLine("Completing anothor work in the main thread...");
            Thread.Sleep(2000);

            Console.WriteLine("The operation completed.");

            Console.ReadLine();
        }

        private static void DoWork(object state)
        {
            // Starting the anasynchronous operation

            Console.WriteLine("Asynchronous operation is starting...");
            Thread.Sleep(3000);
            Console.WriteLine("The operation completed");
        }
    }
}
