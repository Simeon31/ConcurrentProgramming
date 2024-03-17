using System;
using System.Threading;

namespace DeadLockExample03
{
    /*
     This example is different because it uses the underlying thread context to lock the two objects.
     Although this is a rarer case, it can lead to a Deadlock if either thread locks the single object
     and waits for the other thread to lock the other object while the main thread context is blocked and cannot continue its execution.
    */
    class Program
    {
        static object lock1 = new object();
        static object lock2 = new object();
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                lock (lock1)
                {
                    Console.WriteLine("Thread 1: locked lock1");
                    Thread.Sleep(1000);

                    lock (lock2)
                    {
                        Console.WriteLine("Thread 1: locked lock2");
                    }
                }
            });

            Thread thread2 = new Thread(() =>
            {
                lock (lock2)
                {
                    Console.WriteLine("Thread 2: locked lock1");
                    Thread.Sleep(1000);

                    lock (lock1)
                    {
                        Console.WriteLine("Thread 2: locked lock2");
                    }
                }
            });

            thread1.Start();
            thread2.Start();

            Thread.Sleep(2000);

            lock (lock1)
            {
                Console.WriteLine("Main thread: locked lock1");

                lock (lock2)
                {
                    Console.WriteLine("Main thread: locked lock2");
                }
            }
        }
    }
}
