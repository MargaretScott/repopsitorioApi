using System;

namespace CSharp_08_Metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            PintarSeparador();

            string tituloSeccion = "Ejemplo de métodos en C#";

            PintarTitulo(tituloSeccion);

            PintarSeparador();
            
            Console.WriteLine("Como estamos en " + ObtenerAñoActual());

            int miEdad = 27;

            Console.WriteLine("y tienes " + miEdad + " años,");

            string miAño = ObtenerAñoNacimiento(miEdad);

            Console.WriteLine("naciste en " + miAño);

            PintarSeparador();
        }

        /// <summary>
        /// Método de tipo procedimiento porque no devuelve ningún valor.
        /// </summary>
        static void PintarSeparador()
        {
            for (int i = 0; i < 45; i++) 
            { Console.Write('-'); }

            Console.WriteLine();
        }

        /// <summary>
        /// Método de tipo procedimiento que además recibe un parámetro.
        /// </summary>
        /// <param name="titulo">Recibe una cadena para pintar la línea del título.</param>
        static void PintarTitulo(string titulo, int num = 0)
        {
            int caracteres = 45 - titulo.Length;

            for (int i = 0; i < caracteres; i++) Console.Write('|');

            Console.WriteLine(titulo);
        }

        /// <summary>
        /// Método de tipo función porque devuelve un valor mediante return.
        /// </summary>
        /// <returns>Devuelve el año actual como un número entero.</returns>
        static int ObtenerAñoActual()
        {
            int añoActual = DateTime.Now.Year;

            return añoActual;
        }

        /// <summary>
        /// Método de tipo función que además recibe un parámetro.
        /// </summary>
        /// <param name="edad">Recibe un número entero que indica la edad.</param>
        /// <returns>Devuelve los posibles años de nacimiento como texto.</returns>
        static string ObtenerAñoNacimiento(int edad)
        {
            int añoActual = ObtenerAñoActual();

            int añoNacimiento = añoActual - edad;

            return añoNacimiento - 1 + " o " + añoNacimiento;
        }
    }
}
