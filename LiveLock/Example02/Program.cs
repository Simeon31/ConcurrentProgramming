using System;
using System.Threading;

namespace LivelockExample02
{
    /*
     * Two threads attempt to access two SemaphoreSlim objects. 
     * Each of them blocks the first SemaphoreSlim object and then tries to block the second SemaphoreSlim object. 
     * If it fails to block the second object for a certain amount of time, 
     * the thread releases the first SemaphoreSlim object and waits for a certain amount of time before trying again. 
     * The problem is that both threads 
     * can block each other while releasing the SemaphoreSlim objects because they cannot block two SemaphoreSlim objects at the same time.
     */
    class Program
    {
        static SemaphoreSlim semaphoreSlim1 = new SemaphoreSlim(1);
        static SemaphoreSlim semaphoreSlim2 = new SemaphoreSlim(1);

        static void Main(string[] args)
        {
            Thread thread1 = new(() =>
            {
                while (true)
                {
                    semaphoreSlim1.Wait();

                    if (semaphoreSlim2.Wait(100))
                    {
                        // Executable code, when thread is blocked
                        semaphoreSlim2.Release();
                    }
                    else
                    {
                        semaphoreSlim1.Release();
                        Thread.Sleep(10);
                    }
                }
            });

            Thread thread2 = new(() =>
            {
                while (true)
                {
                    semaphoreSlim2.Wait();

                    if (semaphoreSlim1.Wait(100))
                    {
                        // Executable code, when thread is blocked
                        semaphoreSlim1.Release();
                    }
                    else
                    {
                        semaphoreSlim2.Release();
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
