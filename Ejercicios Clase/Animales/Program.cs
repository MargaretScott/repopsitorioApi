using Animales.Clases;

namespace Animales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Escriba el nombre de su perro");
            string nombre = Console.ReadLine();

            Perro nuevoPerro = new Perro();

            nuevoPerro.SetNombre(nombre);
            nuevoPerro.GetNombre();
            nuevoPerro.Comer();
        }

    }
}