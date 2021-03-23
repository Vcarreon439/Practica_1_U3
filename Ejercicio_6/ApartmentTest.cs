using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ejercicio_6
{
    class ApartmentTest
    {
        [Obsolete]
        static void Main()
        {
            Console.Title = "Ejercicio 6";
            Thread newThread = new Thread(new ThreadStart(ThreadMethod));
            newThread.SetApartmentState(ApartmentState.MTA);
            // The following line is ignored since
            // ApartmentState can only be set once.
            // newThread.SetApartmentState(ApartmentState.STA);
            Console.WriteLine("ThreadState: {0}, ApartmentState: {1}", newThread.ThreadState, newThread.ApartmentState);
            newThread.Start();
            // Wait for newThread to start and go to sleep.
            Thread.Sleep(300);
            try
            {
                // This causes an exception since newThread is sleeping.
                newThread.SetApartmentState(ApartmentState.STA);
            }
            catch (ThreadStateException stateException)
            {
                Console.WriteLine("\n{0} caught:\n" +
                "Thread is not in the Unstarted or Running state.",
                stateException.GetType().Name);
                Console.WriteLine("ThreadState: {0}, ApartmentState: {1}",
                newThread.ThreadState, newThread.GetApartmentState());
            }

            Console.ReadKey();

        }


        static void ThreadMethod()
        {
            Thread.Sleep(1000);
        }

    }
}
