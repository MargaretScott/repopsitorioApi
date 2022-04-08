using Animales.Interfaces;

namespace Animales.Clases
{
    public class Perro : IPerro
    {
        private string Nombre { get; set; }

        public void Comer()
        {
            Console.WriteLine("Comiendo");
        }

        public void GetNombre()
        {
            Console.WriteLine(Nombre);
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }
    }
}
