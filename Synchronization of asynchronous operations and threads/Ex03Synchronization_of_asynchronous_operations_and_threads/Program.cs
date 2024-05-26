using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Ex03Synchronization_of_asynchronous_operations_and_threads
{
    class Program
    {
        static BlockingCollection<int> queue = new BlockingCollection<int>(3); // creating blocking queue
        static void Main(string[] args)
        {
            Thread producerThread = new Thread(Producer);
            Thread consumedThread = new Thread(Consumer);

            producerThread.Start();
            consumedThread.Start();

            Console.ReadLine();
            queue.CompleteAdding();
        }

        private static void Producer()
        {
            for (int i = 0; i < 5; i++)
            {
                queue.Add(i);
                Console.WriteLine("Produced element: " + i);
                Thread.Sleep(500);
            }
        }

        private static void Consumer()
        {
            foreach (var el in queue.GetConsumingEnumerable())
            {
                Console.WriteLine("Consumed element: " + el);
                Thread.Sleep(1000);
            }
        }
    }
}
