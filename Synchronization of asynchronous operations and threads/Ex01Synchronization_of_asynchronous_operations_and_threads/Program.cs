using System;
using System.Threading;

namespace Ex01Synchronization_of_asynchronous_operations_and_threads
{
    class Program
    {
        static Mutex mutex = new Mutex(); // Create a mutex
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
            mutex.WaitOne(); // blocks the current thread

            // Critical section
            Console.WriteLine("Thread {0} entered in critical section", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} was released from the critical section", Thread.CurrentThread.ManagedThreadId);

            mutex.ReleaseMutex();
        }
    }
}
