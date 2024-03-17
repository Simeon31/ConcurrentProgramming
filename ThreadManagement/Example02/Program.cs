using System;
using System.Threading;

namespace ThreadManagement_Example02
{
    class Program
    {
        static int sharedVariable = 0;
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Thread producer = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (lockObject)
                    {
                        sharedVariable++;
                        Console.WriteLine("Produced: " + sharedVariable);
                    }
                    Thread.Sleep(100);
                }
            });
            producer.Start();

            Thread consumer = new Thread(() =>
            {
                while (true)
                {
                    lock (lockObject)
                    {
                        if (sharedVariable > 0)
                        {
                            sharedVariable--;
                            Console.WriteLine("Consumed: " + sharedVariable);
                        }
                    }
                }
            });
            consumer.Start();

            producer.Join();
            consumer.Join();
        }
    }
}
