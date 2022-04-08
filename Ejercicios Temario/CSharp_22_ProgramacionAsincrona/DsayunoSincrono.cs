using System;
using CSharp_22_ProgramacionAsincrona.Ingredientes;

namespace CSharp_22_ProgramacionAsincrona
{
    class MainClass
    {
        // Ejemplo desayuno: Cafe, triturar tomate, aceite, tostada y zumo de manera sincrono
        public static void Main(string[] args)
        {
            // Ejemplo desayuno: Cafe, triturar tomate, aceite, tostada y zumo
            // De forma sincrona
            Cafe cup = HacerCafe();
            Console.WriteLine("Cafe listo");
            Console.WriteLine("Tomate listo");            
            Tostada tostada = TostarTostada(2);
            Console.WriteLine("Tostadas listas");
            AplicarAceite(tostada);
            AplicarTomate(tostada);
            Console.WriteLine("Tostadas con tomate y aceite listas");
            Zumo zumo = HacerZumo();
            Console.WriteLine("Zumo listo");

            Console.WriteLine("Desayuno terminado!");
        }

        private static Zumo HacerZumo()
        {
            Console.WriteLine("    Zumo expremiendose....");
            return new Zumo();
        }

        private static Tostada TostarTostada(int v)
        {
            Console.WriteLine("    Tostadora haciendo su trabajo....");
            return new Tostada();
        }

        private static Cafe HacerCafe()
        {
            Console.WriteLine("    Cafe haciendose....");
            return new Cafe();
        }

        private static void AplicarTomate(Tostada toast)
        {
            Console.WriteLine("    Echando tomate en la tostada....");
        }

        private static void AplicarAceite(Tostada toast)
        {
            Console.WriteLine("    Echando aceite en la tostada....");
        }
    }
}
