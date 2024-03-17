using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    class FirstThread
    {
        public void DoTask1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Thread1:job({0})", i); // Prints the current iteration number for the first thread to the console

            }
        }
        public void DoTask2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Thread2:job({0})", i); // Prints the current iteration number for the second thread to the console
            }
        }

    }
}
