using System;
using System.Threading;

namespace Ejercicio_7
{
    class Test
    {
        static TimeSpan waitTime = new TimeSpan(0, 0, 15);
        public static void Main()
        {
            Console.Title = $"Ejercicio 7 - {waitTime.Seconds}s";
            Thread newThread =
            new Thread(new ThreadStart(Work));
            newThread.Start();
            if (newThread.Join(waitTime + waitTime))
            {
                Console.WriteLine("New thread terminated.");
            }
            else
            {
                Console.WriteLine("Join timed out.");
            }

            Console.ReadKey();
        }
        static void Work()
        {
            Thread.Sleep(waitTime);
        }

    }
}
