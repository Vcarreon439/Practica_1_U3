using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2_Hilos_1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 2";
            Subproceso sub1 = new Subproceso("Rosita");
            Subproceso sub2 = new Subproceso("El Tuercas");
            Subproceso sub3 = new Subproceso("Pablito");

            Console.WriteLine("Iniciando Subprocesos");
            sub1.start();
            sub2.start();
            sub3.start();
            Console.WriteLine("Subprocesos iniciciados y termina main");

            Console.ReadKey();
        }//main
    }
}
