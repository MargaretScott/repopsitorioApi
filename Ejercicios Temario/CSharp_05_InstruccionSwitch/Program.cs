using System;

namespace CSharp_05_InstruccionSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            int nota = 8;
            Console.WriteLine("Nota: " + nota);

            // Instrucción SWITCH
            Console.Write("Instrucción SWITCH : ");
            switch (nota)
            {
                case 0:
                    Console.WriteLine("No presentado");
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Suspenso");
                    break;
                case 5:
                case 6:
                    Console.WriteLine("Aprobado");
                    break;
                case 7:
                case 8:
                    Console.WriteLine("Notable");
                    break;
                case 9:
                    Console.WriteLine("Sobresaliente");
                    break;
                case 10:
                    Console.WriteLine("Matrícula");
                    break;
                default:
                    Console.WriteLine("Nota errónea");
                    break;
            }

            // Instrucción IF-ELSE equivalente
            Console.Write("Instrucción IF-ELSE: ");
            if (nota == 0)
            {
                Console.WriteLine("No presentado");
            }
            else if (nota == 1 || nota == 2 || nota == 3 || nota == 4)
            {
                Console.WriteLine("Suspenso");
            }
            else if (nota == 5 || nota == 6)
            {
                Console.WriteLine("Aprobado");
            }
            else if (nota == 7 || nota == 8)
            {
                Console.WriteLine("Notable");
            }
            else if (nota == 9)
            {
                Console.WriteLine("Sobresaliente");
            }
            else if (nota == 10)
            {
                Console.WriteLine("Matrícula");
            }
            else
            {
                Console.WriteLine("Nota errónea");
            }
        }
    }
}
