using EjercicioCompletoLinq.Entidades;

namespace EjercicioCompletoLinq.Interfaces
{
    public interface IMetodosProfesores
    {
        List<ProfesorExtendido> GetProfesoresJoin(int pagina,
                                                  int numeroRegistros,
                                                  string? filtroPoblacion = null);
    }
}
