namespace EjercicioEjemploCadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            string palabraInicial = "Hola";

            Console.WriteLine($"La tercera letra de Hola es {palabraInicial[2]}");

            Console.WriteLine($"La longitud de Hola es {palabraInicial.Length}");

            Console.WriteLine($"Una subcadena de Hola es {palabraInicial.Substring(1,3)}");

            string frase = "Estoy dando clase de .NET";

            Console.WriteLine($"{frase.Replace(".NET", "Angular")}");

            string[] palabras = frase.Split(' ');

            int posicionPalabra = 0;

            for(int i = 0; i < palabras.Length; i++)
            {
                //Si mi palabra es .NET -> posicionPalabra = i;
                if(palabras[i] == ".NET")
                {
                    posicionPalabra = i + 1;
                    break;
                }
            }

            Console.WriteLine($"\'.NET\' es la palabra número {posicionPalabra} de la frase \'Estoy dando clase de .NET\'");

            posicionPalabra = 1;

            foreach (string palabra in palabras)
            {
                if (palabra == ".NET")
                {
                    break;
                }
                posicionPalabra++;
            }

            Console.WriteLine($"\'.NET\' es la palabra número {posicionPalabra} de la frase \'Estoy dando clase de .NET\'");

        }

    }

}
