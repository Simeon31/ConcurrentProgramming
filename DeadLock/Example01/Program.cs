using System;
using System.Threading;

namespace DeadLockExample01
{
    /*
     In this example, we have two threads trying to lock two objects in different order.
     This can lead to a Deadlock if thread 1 locks lock1 and tries to lock lock2 while thread 2 has already locked lock2
     and expects to lock lock1. The program will be blocked in this case.
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
                        Thread.Sleep(1000);
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
                        Thread.Sleep(1000);
                    }
                }
            });

            thread1.Start();
            thread2.Start();
        }
    }
}
