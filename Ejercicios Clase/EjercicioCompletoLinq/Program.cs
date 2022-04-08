using EjercicioCompletoLinq.Clases;
using EjercicioCompletoLinq.Entidades;

namespace EjercicioCompletoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            MetodosAlumnos nuevoMetodoAlumnos = new MetodosAlumnos();

            List<AlumnoExtendido> listaAlumnos = nuevoMetodoAlumnos.GetAlumnosJoin(1,
                                                                                   20);

            //ForEach y Console WriteLine
            foreach(AlumnoExtendido alumno in listaAlumnos)
            {
                Console.WriteLine($"El alumno/a {alumno.NombreAlumno} esta en la clase {alumno.NombreClase} con nota media {alumno.NotaMediaAlumno}. Este alumno/a vive en {alumno.NombrePoblacion}");
            }

            Console.WriteLine("----------------------------Profesores------------------------------");

            MetodosProfesores nuevoMetodoProfesores = new MetodosProfesores();

            List<ProfesorExtendido> listaProfesores = nuevoMetodoProfesores.GetProfesoresJoin(1,
                                                                                              2,
                                                                                              "Madrid");

            //ForEach y Console WriteLine
            foreach (ProfesorExtendido profesor in listaProfesores)
            {
                Console.WriteLine($"El profesor/a {profesor.Nombre} esta en la clase {profesor.NombreClase}. Este profesor/a vive en {profesor.NombrePoblacion}");
            }
        }

    }

}
