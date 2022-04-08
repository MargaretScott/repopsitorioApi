namespace EjercicioEjemploCadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Voy a manipular una cadena";

            int posicionLetra = test.IndexOf("una");

            Console.WriteLine(posicionLetra);

            Console.WriteLine(test);

            string test2 = test.Replace("manipular", "jugar");

            Console.WriteLine(test2);

            test2 = test.Substring(0, 3);

            Console.WriteLine(test);

            string cadena1 = "Hola";

            string cadena2 = "Me llamo";

            string cadena3 = "Pedro";

            string fraseFinal = $"{cadena1} {cadena2} {cadena3} y tengo 39 años";

            Console.WriteLine(fraseFinal);

            string fraseConcatenada = string.Concat(cadena1, " ", cadena2, " ", cadena3);

            Console.WriteLine(fraseConcatenada);

            Console.WriteLine(test[2]);

            Console.WriteLine(test[test.IndexOf("y")]);

            int posicionCadena = test.IndexOf("Pedro");

            Console.WriteLine(posicionCadena);

            //Usamos indexof para buscar una palabara en una cadena, si devuelve -1, es que la palabara no esta en la cadena
            if(test.IndexOf("Pedro") < 0)
            {
                Console.WriteLine("La palabra Pedro no esta en la cadena");
            }

            //Split de una cadena por caracter
            string[] palabras = test.Split(' ');

            foreach(string palabra in palabras)
            {
                Console.WriteLine(palabra);
            }

            //ToCharArray que convierte una cadena en un array de tipo Char
            char[] caracteres = test.ToCharArray();

            foreach (char caracter in caracteres)
            {
                Console.WriteLine(caracter);
            }

            //Pasar a mayusculas
            string mayusculas = test.ToUpper();

            Console.WriteLine(mayusculas);

            //Pasar a minusculas
            string minusculas = test.ToLower();

            Console.WriteLine(minusculas);

            test = $"  {test} ";

            Console.WriteLine(test);

            //Trim limpiar espacios iniciales y finales en una cadena
            string fraseSinEspacios = test.Trim(' ');

            Console.WriteLine(fraseSinEspacios);
        }
    }

}
