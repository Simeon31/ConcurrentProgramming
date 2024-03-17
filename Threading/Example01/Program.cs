using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstThread ft = new FirstThread(); // An object of the FirstThread class is created
            Thread t1 = new Thread(new ThreadStart(ft.DoTask1)); // Creates a first thread that will execute the DoTask1 method
            Thread t2 = new Thread(new ThreadStart(ft.DoTask2)); // Creates a second thread that will execute the DoTask2 method

            t1.Start(); // The first thread is started
            t2.Start(); // The second thread is started
        }
    }
}
