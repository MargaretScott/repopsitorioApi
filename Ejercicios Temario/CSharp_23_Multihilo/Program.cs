using System;
using System.Threading;

namespace CSharp_23_Multihilo
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hilo principal empieza");
            // Crear dos hilos 
            Thread t1 = new Thread(Method1) { Name = "Hilo 1" };
            Thread t2 = new Thread(Method2) { Name = "Hilo 2" };

            // Lanzar los hilos
            t2.Start();
            t1.Start();            

            Console.WriteLine("Hilo principal terminado");
        }

        static void Method1()
        {
            //Muestra los números del 0 al 10 
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(" Metodo 1: {0} ({1})", i, Thread.CurrentThread.Name);
            }
        }

        static void Method2()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("  Metodo 2: {0} ({1})", i, Thread.CurrentThread.Name);
                if (i == 5)
                {
                    // Espera 4 segundos
                    Console.WriteLine("   Espera empezada....");                    
                    Thread.Sleep(40000);
                    Console.WriteLine("   Espera terminada.");
                }
            }
        }

    }
}