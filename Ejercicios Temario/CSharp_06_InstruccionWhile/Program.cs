using System;

namespace CSharp_06_InstruccionWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int aforoMax = 100;
            Console.WriteLine("Aforo máximo: " + aforoMax);
            int entradas = 0;

            // Instrucción WHILE (se ejecuta 0 o más veces)
            while (entradas < aforoMax)
            {
                Console.Write('X');
                entradas++;
                if (entradas % 20 == 0) Console.WriteLine();
            }

            Console.WriteLine("Aforo completo.");
            Console.WriteLine("Entradas vendidas: " + entradas);
            Console.WriteLine("WHILE primero comprueba y luego ejecuta.");

            Console.WriteLine();

            int numero = 10;

            Console.WriteLine("Busca un múltiplo de 5:");
            // Instrucción DO-WHILE (se ejecuta al menos 1 vez)
            do
            {
                Console.WriteLine("¿" + numero + " es múltiplo de 5?");
                numero++;
            } while (numero % 5 != 0);
            
            Console.WriteLine("¡¡¡" + numero + " es múltiplo de 5!!!");
            Console.WriteLine("DO-WHILE primero ejecuta y luego comprueba.");
        }
    }
}
