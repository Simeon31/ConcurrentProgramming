using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Livelocks
{
    /*  
     Two threads attempt to access two blocking queues. Each of them tries to remove an element from one queue and add it to the other queue.
     The problem is that if one of the threads blocks when trying to remove an item from the queue,
     the other thread also blocks when trying to add an item to the queue because the queue is blocking.
     This can lead to a situation where both threads are waiting for each other to release the queue before continuing their execution.
    */
    class Program
    {
        static ConcurrentQueue<int> queue1 = new();
        static ConcurrentQueue<int> queue2 = new();

        static void Main(string[] args)
        {
            Thread thread1 = new(() =>
            {
                while (true)
                {
                    int item;
                    if (queue1.TryDequeue(out item))
                    {
                        queue2.Enqueue(item);
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
            });

            Thread thread2 = new(() =>
            {
                while (true)
                {
                    int item;
                    if (queue2.TryDequeue(out item))
                    {
                        queue1.Enqueue(item);
                    }
                    else
                    {
                        Thread.Sleep(10);
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
