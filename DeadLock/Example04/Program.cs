using System;
using System.Threading;

namespace Example04
{
    /*
     In this example, two threads try to lock four objects in different order.
     Thread 1 tries to lock lock1 first and thread 2 tries to lock lock4 first.
     If both threads manage to lock their objects, then they will block each other when they try to
     lock the remaining objects, which can lead to Deadlock.
    */

    class Program
    {
        static object lock1 = new object();
        static object lock2 = new object();
        static object lock3 = new object();
        static object lock4 = new object();

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

                        lock (lock3)
                        {
                            Console.WriteLine("Thread 1: locked lock3");
                            Thread.Sleep(1000);
                        }

                        lock (lock4)
                        {
                            Console.WriteLine("Thread 1: locked lock4");
                            Thread.Sleep(1000);
                        }
                    }
                }
            });

            Thread thread2 = new Thread(() =>
            {
                lock (lock4)
                {
                    Console.WriteLine("Thread 2: locked lock4");
                    Thread.Sleep(1000);

                    lock (lock3)
                    {
                        Console.WriteLine("Thread 2: locked lock3");
                        Thread.Sleep(1000);

                        lock (lock2)
                        {
                            Console.WriteLine("Thread 2: locked lock2");
                            Thread.Sleep(1000);
                        }

                        lock (lock1)
                        {
                            Console.WriteLine("Thread 2: locked lock1");
                            Thread.Sleep(1000);
                        }
                    }
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
    }
}
