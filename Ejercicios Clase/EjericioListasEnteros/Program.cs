namespace EjercicioListasEnteros
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>
            { 1,2,3 };

            List<int> lista2 = new List<int>
            { 4,5,6 };

            //Unir listas
            lista1.AddRange(lista2);

            Console.WriteLine("Listado unido con todos los valores");

            //Sacar lista 1 por pantalla
            EscribirPantalla(lista1);

            Console.WriteLine($"La lista 1 tiene {lista1.Count} elementos");

            Console.WriteLine($"La lista 2 tiene {lista2.Count} elementos");

            //Borrar el valor 1 de la lista 1
            lista1.Remove(1);

            Console.WriteLine("Eliminar el valor 1");

            //Sacar lista 1 por pantalla
            EscribirPantalla(lista1);

            //Borrar el valor de la posicion 2 de la lista 1
            lista1.RemoveAt(2);

            Console.WriteLine("Eliminar el valor de la posición 2");

            //Sacar lista 1 por pantalla
            EscribirPantalla(lista1);

            //Añadir el valor 1 a la lista
            lista1.Add(1);

            Console.WriteLine("Añadir el valor 1");

            //Sacar lista 1 por pantalla
            EscribirPantalla(lista1);

            //Ordenar la lista 1
            lista1.Sort();

            Console.WriteLine("Ordenar la lista 1");

            //Sacar lista 1 por pantalla
            EscribirPantalla(lista1);

        }

        private static void EscribirPantalla(List<int> lista)
        {
            foreach(int elemento in lista)
            {
                Console.WriteLine(elemento);
            }
        }

    }

}
