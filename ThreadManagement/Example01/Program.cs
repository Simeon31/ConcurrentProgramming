using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a shared queue
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            //Create and start a producer thread
            Thread producer = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    queue.Enqueue(i);
                    Console.WriteLine("Produced: " + i);
                    Thread.Sleep(100);
                }
            });
            producer.Start();

            // Create and start a consumer thread
            Thread consumer = new Thread(() =>
            {
                while (true)
                {
                    if (queue.TryDequeue(out int result))
                    {
                        Console.WriteLine("Consumed: " + result);
                    }
                }
            });
            consumer.Start();

            // Wait for the producer and consumer threads to finish
            producer.Join();
            consumer.Join();
        }
    }
}
