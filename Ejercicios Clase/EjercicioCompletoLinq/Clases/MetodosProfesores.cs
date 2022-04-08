using EjercicioCompletoLinq.Entidades;
using EjercicioCompletoLinq.Interfaces;

namespace EjercicioCompletoLinq.Clases
{
    public class MetodosProfesores : IMetodosProfesores
    {
        public List<ProfesorExtendido> GetProfesoresJoin(int pagina, 
                                                         int numeroRegistros, 
                                                         string? filtroPoblacion = null)
        {
            List<Profesor> listaProfesores = Profesor.GetProfesores();
            List<Clase> listaClases = Clase.GetClases();
            List<Poblacion> listaPoblaciones = Poblacion.GetPoblaciones();

            var query =
                from pro in listaProfesores

                join cla in listaClases on pro.Clase equals cla.Numero
                join pob in listaPoblaciones on pro.PoblacionId equals pob.Id

                where (filtroPoblacion == null || pob.Nombre == filtroPoblacion)

                orderby pro.Nombre

                select new ProfesorExtendido
                {
                    Clase = pro.Clase,
                    FechaDeNacimiento = pro.FechaDeNacimiento,
                    Nombre = pro.Nombre,
                    PoblacionId = pro.PoblacionId,
                    NombreClase = cla.Nombre,
                    NombrePoblacion = pob.Nombre
                };

            int skip = (pagina - 1) * numeroRegistros;

            return query.Skip(skip).Take(numeroRegistros).ToList();
        }
    }
}
