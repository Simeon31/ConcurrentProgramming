using System;
using System.Threading;

namespace LivelockExample04
{
    /*
     * Two threads change the state of two ManualResetEventSlim objects. 
     * Each thread activates the first object and then waits until the second object becomes active. 
     * The problem is that both threads can wait for the activation of the second object 
     * without synchronizing their operations, with the result that neither can move forward. 
     * This is a typical example of livelock.
     */
    class Program
    {
        static ManualResetEventSlim resetEventSlim1 = new();
        static ManualResetEventSlim resetEventSlim2 = new();

        static void Main(string[] args)
        {
            Thread thread1 = new(() =>
            {
                while (true)
                {
                    resetEventSlim1.Set();
                    resetEventSlim2.Wait();
                    // A code that is executing, when the thread is blocked
                }
            });

            Thread thread2 = new(() =>
            {
                while (true)
                {
                    resetEventSlim2.Set();
                    resetEventSlim1.Wait();
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
