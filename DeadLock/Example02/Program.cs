using System;
using System.Threading;

namespace DeadLockExample02
{
    /*
     In this example, we have the same two threads as in the previous example, but instead of starting them and letting them execute asynchronously,
     we use the Join() method to wait for both threads to finish executing before moving forward in the program.
     This can lead to Deadlock,
     if thread 1 locks lock1 and expects thread 2 to lock lock2 while thread 2 is blocked in the Join() method
     and cannot continue its execution.
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


            thread1.Join();
            thread2.Join();
        }
    }
}
