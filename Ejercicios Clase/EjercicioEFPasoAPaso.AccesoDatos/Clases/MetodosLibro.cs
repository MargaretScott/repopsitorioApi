using EjercicioEFPasoAPaso.AccesoDatos.Entidades;

namespace EjercicioEFPasoAPaso.AccesoDatos.Clases
{
    public class MetodosLibro
    {
        public void InsertarDatos(ApplicationDbContext context, Libro libro)
        {
            context.Libros.Add(libro);
        }

        public void BorrarDatos(ApplicationDbContext context, int id)
        {
            Libro? libroEnbbdd = ObtenerLibroPorId(context, id);

            if (libroEnbbdd == null)
            {
                Console.WriteLine("El autor no existe");
            }
            else
            {
                context.Libros.Remove(libroEnbbdd);
            }
        }

        public void ActualizarDatos(ApplicationDbContext context, Libro libro, int id)
        {
            Libro? libroEnbbdd = ObtenerLibroPorId(context, id);

            if (libroEnbbdd == null)
            {
                Console.WriteLine("El autor no existe");
            }
            else
            {
                libroEnbbdd.Titulo = libro.Titulo;
                context.Libros.Update(libroEnbbdd);
            }
        }

        public Libro? ObtenerLibroPorId(ApplicationDbContext context, int id)
        {
            Libro? libroEnbbdd = context.Libros.Where(a => a.Id == id).FirstOrDefault();

            return libroEnbbdd;
        }

        public List<Libro> ObtenerListadoLocalEjemplo()
        {
            return new List<Libro>
            {
                new Libro{Titulo = "Don Quijote de la Mancha", AutorId = 1 },
                new Libro{Titulo = "Historia de dos ciudades", AutorId = 2 },
                new Libro{Titulo = "El Señor de los Anillos", AutorId =3 },
                new Libro{Titulo = "El principito", AutorId = 4 },
                new Libro{Titulo = "El hobbit", AutorId = 3 },
                new Libro{Titulo = "Sueño en el pabellón rojo", AutorId =5 },
                new Libro{Titulo = "Las aventuras de Alicia en el país de las maravillas", AutorId =6 },
                new Libro{Titulo = "Diez negritos", AutorId = 7 },
                new Libro{Titulo = "El león, la bruja y el armario", AutorId =8 },
                new Libro{Titulo = "El código Da Vinci", AutorId =9 },
                new Libro{Titulo = "El guardián entre el centeno", AutorId =10 }
            };
        }

        public Libro? ObtenerLibroPorTitulo(ApplicationDbContext context, string titulo)
        {
            var query =
                from libro in context.Libros
                where libro.Titulo == titulo
                select libro;

            return query.FirstOrDefault();
        }
    }
}
