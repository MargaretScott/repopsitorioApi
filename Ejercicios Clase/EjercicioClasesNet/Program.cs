namespace EjercicioClasesNet
{
    public class CalculadoraBasicaSwitch
    {
        public static void Main(string[] args)
        {
            Persona persona = new Persona();

            Console.WriteLine("Escriba su nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba su apellido: ");
            string apellidos = Console.ReadLine();
            Console.WriteLine("Escriba su edad: ");
            int edad = int.Parse(Console.ReadLine());

            persona.Nombre = nombre;
            persona.Apellidos = apellidos;
            persona.Edad = edad;

            int anoNacimiento = persona.CalcularAnoNacimiento(edad);

            Console.WriteLine("Usted nacio en: " + anoNacimiento);
        }

    }
}
