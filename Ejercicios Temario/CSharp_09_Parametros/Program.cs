using System;

namespace CSharp_09_Parametros
{
    class Program
    {
        static void Main(string[] args)
        {
            ParametrosOpcionales(); // No se pasa ningún parámetro.
            ParametrosOpcionales(1); // Se pasa solo el primer parámetro.
            ParametrosOpcionales(numeroB: 1); // Se pasa solo el segundo parámetro.
            ParametrosOpcionales(1, 1); // Se pasan ambos parámetros.

            Console.WriteLine();

            ParametrosPorDefecto(); // Todos los parámetros por defecto.
            ParametrosPorDefecto(1); // Segundo y tercer párámetros por defecto.
            ParametrosPorDefecto(1, true); // Solo tercer párámetro por defecto.
            ParametrosPorDefecto(cadena: "hola"); // Primer y segundo parámetros por defecto.

            Console.WriteLine();

            int miNumero = 9;

            Console.WriteLine("ParametroPorValor antes  : miNumero = " + miNumero);
            ParametroPorValor(miNumero);
            Console.WriteLine("ParametroPorValor después: miNumero = " + miNumero);

            Console.WriteLine();

            Console.WriteLine("ParametroPorReferencia antes  :   miNumero = " + miNumero);
            ParametroPorReferencia(ref miNumero);
            Console.WriteLine("ParametroPorReferencia después:   miNumero = " + miNumero);
        }

        /// <summary>
        /// Método con parámetros opcionales y valores por defecto explícitos.
        /// </summary>
        /// <param name="numeroA">Número opcional. Valor por defecto: 6.</param>
        /// <param name="numeroB">Número opcional. Valor por defecto: 9.</param>
        static void ParametrosOpcionales(int numeroA = 6, int numeroB = 9)
        {
            Console.WriteLine("ParametrosOpcionales: numero A = " + numeroA + ", numeroB = " + numeroB);
        }

        /// <summary>
        /// Método con parámetros opcionales y valores por defecto implícitos según tipo.
        /// </summary>
        /// <param name="numero">El valor entero por defecto es 0.</param>
        /// <param name="booleano">El valor booleano por defecto es false.</param>
        /// <param name="cadena">El valor de texto por defecto es cadena vacía.</param>
        static void ParametrosPorDefecto(int numero = default, bool booleano = default, string cadena = default)
        {
            Console.WriteLine("ParametrosPorDefecto: numero = " + numero + ", booleano = " + booleano + ", cadena = " + cadena);
        }

        /// <summary>
        /// Método con parámetro pasado Por Valor.
        /// </summary>
        /// <param name="numero">Es una copia de la variable.</param>
        static void ParametroPorValor(int numero)
        {
            Console.WriteLine("ParametroPorValor entrada:    copia = " + numero);
            numero++;
            Console.WriteLine("ParametroPorValor salida :    copia = " + numero);
        }

        /// <summary>
        /// Método con parámetro pasado Por Referencia.
        /// </summary>
        /// <param name="numero">Es una referencia a la variable.</param>
        static void ParametroPorReferencia(ref int numero)
        {
            Console.WriteLine("ParametroPorReferencia entrada: referencia = " + numero);
            numero++;
            Console.WriteLine("ParametroPorReferencia salida : referencia = " + numero);
        }
    }
}
