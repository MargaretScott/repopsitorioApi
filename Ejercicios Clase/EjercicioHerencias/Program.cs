namespace EjercicioHerencias
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Crear persona y hacer que salude
            Persona persona = new Persona();
            persona.Saludar();

            //Crear un estudiante, establecer una edad, hacer que salude, mostrar su edad y empezar a estudiar
            Estudiante nuevoEstudiante = new Estudiante();
            nuevoEstudiante.SetEdad(25);
            nuevoEstudiante.Saludar();
            nuevoEstudiante.VerEdad();
            nuevoEstudiante.Estudiar();

            //Crear un profesor, establecer una edad, saludar y empezar la explicacion
            Profesor nuevoProfesor = new Profesor();
            nuevoProfesor.SetEdad(40);
            nuevoProfesor.Saludar();
            nuevoProfesor.Explicar();
        }

    }
}