namespace EjercicioEjemploCadenas2
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "Estoy probando implementaciones de cadenas";

            Console.WriteLine("La longitud de la cadena es: " + cadena.Length);

            string[] palabras = cadena.Split(' ');

            Console.WriteLine($"El número de palabras de la cadena es {palabras.Length}");

            Console.WriteLine(cadena.Replace("probando", "estudiando"));

            int posicion = 1;

            foreach(string palabra in palabras)
            {
                if(palabra == "implementaciones")
                {
                    Console.WriteLine("La posicion de la palabra implementaciones es " + posicion);

                    Console.WriteLine("La palabra implementaciones tiene " + palabra.Length + "caracteres");

                    break;
                }

                posicion++;
            }
        }

    }

}
