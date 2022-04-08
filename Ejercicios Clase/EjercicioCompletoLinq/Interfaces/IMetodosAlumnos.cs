using EjercicioCompletoLinq.Entidades;

namespace EjercicioCompletoLinq.Interfaces
{
    public interface IMetodosAlumnos
    {
        List<AlumnoExtendido> GetAlumnosJoin(int pagina, 
                                             int numeroRegistros, 
                                             char? filtroNombre = null, 
                                             double? filtroNota = null, 
                                             DateTime? filtroFechaDesde = null, 
                                             DateTime? filtroFechaHasta = null);
    }
}
