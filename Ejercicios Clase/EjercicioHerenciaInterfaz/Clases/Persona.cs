using EjercicioHerenciaInterfaz.Interfaces;

namespace EjercicioHerenciaInterfaz.Clases
{
    public class Persona : IPersona
    {
        private string Nombre { get; set; }
        private int Edad { get; set; }

        public void GetAñoNacimiento()
        {
            int añoNacimiento = DateTime.Now.Year - Edad;

            Console.WriteLine("Naci en el año " + añoNacimiento);
        }

        public void GetNombre()
        {
            Console.WriteLine("Me llamo " + Nombre);
        }

        public void SetEdad(int edad)
        {
            Edad = edad;
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }
    }
}
