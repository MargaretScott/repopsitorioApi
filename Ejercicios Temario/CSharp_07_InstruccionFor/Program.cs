using System;

namespace CSharp_07_InstruccionFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int aforoMax = 100;
            Console.WriteLine("Aforo máximo: " + aforoMax);

            // Instrucción FOR (inicializador, condición, iterador)
            for (int i = 0; i < aforoMax; i++)
            {
                Console.Write('X');
                if ((i + 1) % 20 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine("Aforo completo.");

            Console.WriteLine();

            int[] asientosVIP = { 18, 27, 36, 45, 90 };

            Console.WriteLine("Recorrer Array con FOREACH:");

            // Instrucción FOREACH (elemento in colección)
            foreach (var asiento in asientosVIP)
            {
                Console.WriteLine("El asiento " + asiento + " es VIP.");
            }

            Console.WriteLine("Recorrer Array con FOR:");

            // Equivalente a FOREACH con un bucle FOR
            for (int i = 0; i < asientosVIP.Length; i++)
            {
                Console.WriteLine("El asiento " + asientosVIP[i] + " es VIP");
            }
        }
    }
}
