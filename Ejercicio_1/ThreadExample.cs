using System;
using System.Threading;

namespace Ejercicio_1
{
    //En el siguiente ejemplo de código se muestra la funcionalidad de un subproceso simple
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 1";
            Console.WriteLine("Main thread: Start a second thread.");
            // El constructor para la clase "Thread requiere un ThreadStart
            // delegado que representa el metodo que se ejecutará en el hilo
            // C# simplifica la creacion de este delegado.
            Thread t = new Thread(new ThreadStart(ThreadExample.ThreadProc));
            // Start ThreadProc. Note that on a uniprocessor, the new
            // thread does not get any processor time until the main thread
            // is preempted or yields. Uncomment the Thread.Sleep that
            // follows t.Start() to see the difference.
            t.Start();
            //Thread.Sleep(0);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }
            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
           
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join ha finalizado. Presiona Enter para terminar el programa");

            Console.ReadKey();
        }
    }


    // Escenario de un subproceso Simple: Comenzar a correr un metodo estatico
    // En un segundo hilo.
    public class ThreadExample
    {
        // El metodo ThreadProc es llamado cuando el hilo comienza.
        // Este se cicla 10 veces, escribiendo en la consola y cediendo
        // el resto de su tiempo cada vez, y luego termina.
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // cede el resto de su tiempo.
                Thread.Sleep(0);
            }
        }


    }
}
