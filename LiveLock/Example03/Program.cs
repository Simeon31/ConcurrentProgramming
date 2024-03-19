using System;
using System.Threading;

namespace LivelockExample03
{
    /*
     * Two threads exchange the values ​​of two variables using the Interlocked.Exchange method. 
     * The problem is that both threads can change the values ​​of the variables one after the other without synchronizing their operations, 
     * with the result that the variables remain with their initial values.
     */
    class Program
    {
        static int value1 = 0;
        static int value2 = 0;

        static void Main(string[] args)
        {
            Thread thread1 = new(() =>
            {
                while (true)
                {
                    Interlocked.Exchange(ref value1, value2);
                    // A code that is executing, when the thread is blocked
                }
            });

            Thread thread2 = new(() =>
            {
                while (true)
                {
                    Interlocked.Exchange(ref value2, value1);
                    // A code that is executing, when the thread is blocked
                }
            });

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
    }
}
