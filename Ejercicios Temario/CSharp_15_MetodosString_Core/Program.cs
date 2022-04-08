using System;

namespace CSharp_15_MetodosString_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Aprendiendo .Net en CodeHouse Academy";
            Console.WriteLine(texto);

            string academia = "CodeHouse";
            Console.WriteLine($"El texto contiene la palabra {academia} : {texto.Contains(academia)}");

            string subcadena = texto.Substring(8, 16);
            Console.WriteLine($"Substring(8, 16) del texto: {subcadena}");

            string lenguaje = "C#";
            texto = texto.Insert(texto.IndexOf(".Net"), lenguaje);
            Console.WriteLine(texto);

            texto = texto.Replace("Aprendiendo", "Enseñando");
            Console.WriteLine(texto);

            Console.WriteLine();

            string[] palabras = texto.Split(' ');
            int numero = palabras.Length;
            for (int i = 0; i < numero; i++)
            {
                Console.WriteLine($"Palabra {i + 1} de {numero}: {palabras[i]}");
            }

            Console.WriteLine();

            char[] caracteres = texto.ToCharArray();
            foreach (var caracter in caracteres)
            {
                Console.Write($"{caracter} ");
            }
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine(texto);
            Console.WriteLine(texto.ToLower());
            Console.WriteLine(texto.ToUpper());

            Console.WriteLine();

            string espacios = "    espacios      ";
            Console.WriteLine($"Con {espacios}.");
            Console.WriteLine($"Sin {espacios.Trim(' ')}.");

            Console.WriteLine();

            DateTime fecha = DateTime.Now;

            Console.WriteLine("ToString         : " + fecha.ToString());
            Console.WriteLine("ToLongDateString : " + fecha.ToLongDateString());
            Console.WriteLine("ToLongTimeString : " + fecha.ToLongTimeString());
            Console.WriteLine("ToOADate         : " + fecha.ToOADate());
            Console.WriteLine("ToShortDateString: " + fecha.ToShortDateString());
            Console.WriteLine("ToShortTimeString: " + fecha.ToShortTimeString());
            Console.WriteLine("ToLocalTime      : " + fecha.ToLocalTime());
            Console.WriteLine("ToUniversalTime  : " + fecha.ToUniversalTime());
        }
    }
}
