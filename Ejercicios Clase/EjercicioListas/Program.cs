namespace EjercicioListas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicializacion cadenas
            List<string> listaCadenas = new List<string>
            {
                "cadena1",
                "cadena2",
                "cadena3"
            };

            //Carga de cadenas elemento a elemento
            //listaCadenas.Add("cadena1");
            //listaCadenas.Add("cadena2");

            //Cargar listas por rango
            List<string> listaCadenas2 = new List<string>
            {
                "cadena4",
                "cadena5",
                "cadena6"
            };

            //El resultado es una lista con los 6 elementos
            listaCadenas.AddRange(listaCadenas2);

            foreach (string cadena in listaCadenas)
            {
                Console.WriteLine(cadena);
            }

            int numeroElementos = listaCadenas.Count();

            Console.WriteLine("La lista tiene " + numeroElementos + " elementos");

            listaCadenas.Remove("cadena1");
            //Queda una lista con los valores cadena2, cadena3, cadena4, cadena5, cadena6

            foreach (string cadena in listaCadenas)
            {
                Console.WriteLine(cadena);
            }

            listaCadenas.RemoveAt(0);
            //Queda una lista con los valores cadena3, cadena4, cadena5, cadena6

            foreach (string cadena in listaCadenas)
            {
                Console.WriteLine(cadena);
            }

            //listaCadenas.RemoveAll("cadena");

            listaCadenas.Sort();

            foreach (string cadena in listaCadenas)
            {
                Console.WriteLine(cadena);
            }
        }

    }

}
