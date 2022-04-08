using System;

namespace CSharp_02_Operadores
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definifión (Tipo explícito)
            int numeroA;
            // Asignación
            numeroA = 1;
            Console.WriteLine("numeroA: " + numeroA);
            numeroA += 2;
            Console.WriteLine("numeroA = numeroA + 2: " + numeroA);

            Console.WriteLine("numeroA: " + numeroA);
            // Operador de incremento de postfijo
            Console.WriteLine("numeroA++: " + numeroA++); //numeroA = numeroA +1;
            Console.WriteLine("numeroA: " + numeroA);
            // Operador de incremento prefijo
            Console.WriteLine("++numeroA: " + ++numeroA);
            Console.WriteLine("numeroA: " + numeroA);

            // Tipo implícito, el compilador determina el tipo
            var numeroB = 5;
            Console.WriteLine("numeroB: " + numeroB);
            Console.WriteLine("+numeroB: " + +numeroB);
            Console.WriteLine("-numeroB: " + -numeroB);
            Console.WriteLine("-(-numeroB): " + -(-numeroB));
            Console.WriteLine("numeroB: " + numeroB);

            Console.WriteLine(numeroB + " * " + numeroA + " = " + (numeroB * numeroA));
            Console.WriteLine(numeroB + " / " + numeroA + " = " + (numeroB / numeroA));
            Console.WriteLine(numeroB + " % " + numeroA + " = " + (numeroB % numeroA));
            Console.WriteLine(numeroB + " + " + numeroA + " = " + (numeroB + numeroA));
            Console.WriteLine(numeroB + " - " + numeroA + " = " + (numeroB - numeroA));

            var aprobado = true;
            Console.WriteLine("aprobado: " + aprobado);
            var suspenso = !aprobado;
            Console.WriteLine("suspenso: " + suspenso);

            var ganador = true;
            var becado = false;
            Console.WriteLine("ganador: " + ganador);
            Console.WriteLine("becado: " + becado);
            Console.WriteLine(aprobado && ganador);
            Console.WriteLine(aprobado && becado);
            Console.WriteLine(suspenso && ganador);
            Console.WriteLine(suspenso && becado);
            Console.WriteLine(aprobado || ganador);
            Console.WriteLine(aprobado || becado);
            Console.WriteLine(suspenso || ganador);
            Console.WriteLine(suspenso || becado);

            Console.WriteLine(numeroA == numeroB);
            Console.WriteLine(aprobado == ganador);
            Console.WriteLine(numeroA != numeroB);
            Console.WriteLine(!aprobado != suspenso);

            Console.WriteLine("numeroA: " + numeroA);
            Console.WriteLine("numeroB: " + numeroB);

            // Constantes
            const int CONSTANTE_A = 5;
            const int CONSTANTE_B = 10;
            // Esto no se puede hacer:
            //CONSTANTE_B = 3;

            Console.WriteLine(numeroA > numeroB);
            Console.WriteLine(numeroA < numeroB);
            Console.WriteLine(numeroA < CONSTANTE_A);
            Console.WriteLine(numeroA <= CONSTANTE_A);
            Console.WriteLine(numeroB > CONSTANTE_B);
            Console.WriteLine(numeroB >= CONSTANTE_B);
        }
    } 
}
