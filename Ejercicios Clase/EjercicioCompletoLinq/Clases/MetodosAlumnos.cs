using EjercicioCompletoLinq.Entidades;
using EjercicioCompletoLinq.Interfaces;

namespace EjercicioCompletoLinq.Clases
{
    public class MetodosAlumnos : IMetodosAlumnos
    {

        public List<AlumnoExtendido> GetAlumnosJoin(int pagina, 
                                                    int numeroRegistros, 
                                                    char? filtroNombre = null, 
                                                    double? filtroNota = null, 
                                                    DateTime? filtroFechaDesde = null, 
                                                    DateTime? filtroFechaHasta = null)
        {
            List<Clase> listaClases = Clase.GetClases();
            List<Alumno> listaAlumnos = Alumno.GetAlumnos();
            List<Poblacion> listaPoblaciones = Poblacion.GetPoblaciones();

            //Query
            var query =
                from alu in listaAlumnos

                join cla in listaClases on alu.Clase equals cla.Numero
                join pob in listaPoblaciones on alu.PoblacionId equals pob.Id

                let notaMedia = alu.Notas?.Average()

                where (filtroNombre == null || alu.Nombre.StartsWith(filtroNombre.Value))
                   && (filtroNota == null || notaMedia >= filtroNota)
                   && (filtroFechaDesde == null || alu.FechaDeNacimiento >= filtroFechaDesde)
                   && (filtroFechaHasta == null || alu.FechaDeNacimiento <= filtroFechaHasta)

                orderby notaMedia descending

                select new AlumnoExtendido
                {
                    NombreAlumno = alu.Nombre,
                    FechaDeNacimientoAlumno = alu.FechaDeNacimiento,
                    NombreClase = cla.Nombre,
                    NotaMediaAlumno = notaMedia,
                    NombrePoblacion = pob.Nombre
                };

            //if(alu.Notas != null && alu.Notas.Count > 0) -> alu.Notas?.Average()

            int skip = (pagina - 1) * numeroRegistros;

            List<AlumnoExtendido> alumnos = query.Skip(skip).Take(numeroRegistros).ToList();

            return alumnos;
        }

        //private float ConversionAFloat(double? notaMedia)
        //{
        //    float resultado = 0;

        //    float.TryParse(notaMedia?.ToString(), out resultado);

        //    return resultado;
        //}
    }
}
