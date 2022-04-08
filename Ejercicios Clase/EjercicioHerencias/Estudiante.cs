namespace EjercicioHerencias
{
    public class Estudiante : Persona
    {

        public void Estudiar()
        {
            Console.WriteLine("Estoy estudiando");
        }

        public void VerEdad()
        {
            Console.WriteLine("Mi edad es: " + Edad + " años");
        }
    }
}
