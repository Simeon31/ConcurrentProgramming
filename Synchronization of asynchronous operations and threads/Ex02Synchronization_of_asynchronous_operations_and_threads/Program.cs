using System;
using System.Threading;

namespace Ex02Synchronization_of_asynchronous_operations_and_threads
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(2, 2); // Create a smaphore
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(DoWork);
                thread.Start();
            }

            Console.ReadLine();
        }

        private static void DoWork()
        {
            semaphore.WaitOne(); // blocks the current thread

            // Critical section
            Console.WriteLine("Thread {0} entered in critical section", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} was released from the critical section", Thread.CurrentThread.ManagedThreadId);

            semaphore.Release();
        }
    }
}
