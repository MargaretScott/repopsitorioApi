namespace EjercicioHerencias
{
    public class Persona
    {
        public int Edad { get; set; }

        public void Saludar()
        {
            Console.WriteLine("Hola!");
        }

        public void SetEdad(int edad)
        {
            Edad = edad;
        }
    }
}
