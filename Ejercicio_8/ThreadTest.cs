using System;
using System.Threading;

namespace Ejercicio_8
{
    class ThreadTest
    {
        public static void Main()
        {
            Console.Title = "Ejercicio 8";
            ThreadStart myThreadDelegate = new ThreadStart(ThreadWork.DoWork);
            Thread myThread = new Thread(myThreadDelegate);
            myThread.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("In main.");
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }

    }

    public class ThreadWork
    {
        public static void DoWork()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Working thread...");
                Thread.Sleep(100);
            }
        }
    }
}
