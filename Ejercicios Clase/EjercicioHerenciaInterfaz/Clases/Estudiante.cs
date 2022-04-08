using EjercicioHerenciaInterfaz.Interfaces;

namespace EjercicioHerenciaInterfaz.Clases
{
    public class Estudiante : Persona, IEstudiante
    {
        private string Asignatura { get; set; }

        public void GetAsignatura()
        {
            Console.WriteLine("Estoy estudiando la asignatura " + Asignatura);
        }

        public void SetAsignatura(string asignatura)
        {
            Asignatura = asignatura;
        }
    }
}
