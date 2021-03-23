using System;
using System.Threading;

namespace Ejercicio_3_Test
{
    //En el ejemplo de código siguiente se muestra la forma de pasar información a un subproceso que se está
    //interrumpiendo.


    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 3";
            Thread newThread = new Thread(new ThreadStart(TestMethod));
            newThread.Start();
            Thread.Sleep(1000);
            // Abort newThread.
            Console.WriteLine("Main aborting new thread.");
            newThread.Abort("Information from Main.");
            // Wait for the thread to terminate.
            newThread.Join();
            Console.WriteLine("New thread terminated - Main exiting.");

            Console.ReadKey();
        }

        static void TestMethod()
        {
            try
            {
                while (true)
                {
                    
                    Console.WriteLine("New thread running.");
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException abortException)
            {
                Console.WriteLine((string)abortException.ExceptionState);
            }
        }



    }
}
