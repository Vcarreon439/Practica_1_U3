using System;
using System.Threading;

namespace Ejercicio_2_Hilos_1
{
    class Subproceso
    {
        private Thread hilo;
        private int tiempodeinactividad;
        private string nombre;
        ///////////////
        private Random R;
        private int semilla;
        ///////////////
        public Subproceso(string n)
        {
            this.nombre = n;
            ////////////////////////////////////
            this.semilla = (int)DateTime.Now.Ticks;
            Thread.Sleep(100);
            this.R = new Random(this.semilla);
            /////////////////////////////////////
            this.tiempodeinactividad = R.Next(10001);

        }
        public void Run()
        {
            Console.WriteLine(this.nombre +
            " va a estar dormido durante " +
            this.tiempodeinactividad + " segundos");
            Thread.Sleep(this.tiempodeinactividad);
            Console.WriteLine(this.nombre + " termino su inactividad");
        }//fin run

        public void start()
        {
            ///////////////////////////////////////////
            this.hilo = new Thread(new ThreadStart(Run));
            this.hilo.Start();
            //this.hilo.Abort();
            /////////////////////////////////////////////
        }


    }
}
