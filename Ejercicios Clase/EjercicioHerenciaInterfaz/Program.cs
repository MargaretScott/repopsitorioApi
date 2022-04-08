using EjercicioHerenciaInterfaz.Clases;

namespace EjercicioHerenciaInterfaz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Como te llamas?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cuantos años tienes?");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Que asignatura estas estudiando?");
            string asignatura = Console.ReadLine();

            Estudiante nuevoEstudiante = new Estudiante();

            nuevoEstudiante.SetNombre(nombre);
            nuevoEstudiante.SetEdad(edad);
            nuevoEstudiante.SetAsignatura(asignatura);
            nuevoEstudiante.GetNombre();
            nuevoEstudiante.GetAñoNacimiento();
            nuevoEstudiante.GetAsignatura();
        }
    }

}