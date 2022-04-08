using System;

namespace CSharp_04_InstruccionIfElse
{
    class Program
    {
        static void Main(string[] args)
        {
            bool aprobado = true;
            int nota = 8;

            // Instrucción IF
            if (aprobado)
            {
                Console.WriteLine("Alumno aprobado: " + aprobado);
            }

            // Instrucción IF-ELSE
            if (nota < 5)
            {
                Console.WriteLine("Alumno suspenso con un " + nota);
            }
            else
            {
                Console.WriteLine("Alumno aprobado con un " + nota);
            }

            // Instrucción ELSEIF
            if (nota < 5)
            {
                Console.WriteLine("Alumno suspenso con un " + nota);
            }
            else if (nota >= 7)
            {
                Console.WriteLine("Alumno con buena nota: " + nota);
            }
            else
            {
                Console.WriteLine("Alumno aprobado con un " + nota);
            }

            // Instrucciones IF-ELSE anidadas
            if (nota < 5)
            {
                Console.WriteLine("Alumno suspenso con un " + nota);
            }
            else if (nota >= 7)
            {
                Console.Write("Alumno con buena nota: " + nota);
                if (nota > 9)
                {
                    Console.WriteLine(" (sobresaliente)");
                }
                else
                {
                    Console.WriteLine(" (notable)");
                }
            }
            else
            {
                Console.WriteLine("Alumno aprobado con un " + nota);
            }
        }
    }
}
