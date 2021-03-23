using System;
using System.Security.Permissions;
using System.Threading;

[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, ControlThread = true)]

namespace Ejercicio_4
{
    //En el ejemplo de código siguiente se muestra el comportamiento de un subproceso en ejecución que se interrumpe y
    //queda posteriormente bloqueado.

    class StayAwake
    {
        bool sleepSwitch = false;
        public bool SleepSwitch
        {
            set { sleepSwitch = value; }
        }
        public StayAwake() { }

        public void ThreadMethod()
        {
            Console.WriteLine("newThread is executing ThreadMethod.");
            while (!sleepSwitch)
            {
                // Use SpinWait instead of Sleep to demonstrate the
                // effect of calling Interrupt on a running thread.
                Thread.SpinWait(10000);
            }
            try
            {
                Console.WriteLine("newThread going to sleep.");
                // When newThread goes to sleep, it is immediately
                // woken up by a ThreadInterruptedException.
                Thread.Sleep(1000/*Timeout.Infinite*/);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("newThread cannot go to sleep - " +
                $"interrupted by main thread. {e.Message}");
            }
        }
    }

    class ThreadInterrupt
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 4";
            StayAwake stayAwake = new StayAwake();
            Thread newThread =
            new Thread(new ThreadStart(stayAwake.ThreadMethod));
            newThread.Start();
            // The following line causes an exception to be thrown
            // in ThreadMethod if newThread is currently blocked
            // or becomes blocked in the future.
            newThread.Interrupt();
            Console.WriteLine("Main thread calls Interrupt on newThread.");
            // Tell newThread to go to sleep.
            stayAwake.SleepSwitch = true;
            // Wait for newThread to end.
            newThread.Join();

            Console.ReadKey();
        }
    }
}
