using EjercicioEFPasoAPaso.AccesoDatos.Entidades;

namespace EjercicioEFPasoAPaso.AccesoDatos.Clases
{
    public class MetodosAutor
    {
        public void InsertarDatos(ApplicationDbContext context, Autor autor)
        {
            context.Autores.Add(autor);
        }

        public void BorrarDatos(ApplicationDbContext context, int id)
        {
            Autor? autorEnbbdd = ObtenerAutorPorId(context, id);

            if (autorEnbbdd == null)
            {
                Console.WriteLine("El autor no existe");
            }
            else
            {
                context.Autores.Remove(autorEnbbdd);
            }
        }

        public void ActualizarDatos(ApplicationDbContext context, Autor autor, int id)
        {
            Autor? autorEnbbdd = ObtenerAutorPorId(context, id);

            if (autorEnbbdd == null)
            {
                Console.WriteLine("El autor no existe");
            }
            else
            {
                autorEnbbdd.Nombre = autor.Nombre;
                context.Autores.Update(autorEnbbdd);
            }
        }

        public Autor? ObtenerAutorPorId(ApplicationDbContext context, int id)
        {
            Autor? autorEnbbdd = context.Autores.Where(a => a.Id == id).FirstOrDefault();

            return autorEnbbdd;
        }

        public List<Autor> ObtenerListadoLocalEjemplo()
        {
            return new List<Autor>
            {
                new Autor{Id = 1, Nombre = "Miguel de Cervantes" },
                new Autor{Id = 2, Nombre = "Charles Dickens"},
                new Autor{Id = 3, Nombre = "J. R. R. Tolkien"},
                new Autor{Id = 4, Nombre = "Antoine de Saint-Exupéry"},
                new Autor{Id = 5, Nombre = "Cao Xueqin"},
                new Autor{Id = 6, Nombre = "Lewis Car"},
                new Autor{Id = 7, Nombre = "Agatha Christie"},
                new Autor{Id = 8, Nombre = "C. S. Lewis"},
                new Autor{Id = 9, Nombre = "Dan Brown"},
                new Autor{Id = 10, Nombre = "J. D. Salinger"},
            };
        }

        public Autor? ObtenerAutorPorNombre(ApplicationDbContext context, string nombre)
        {
            var query =
                from autor in context.Autores
                where autor.Nombre == nombre
                select autor;

            return query.FirstOrDefault();
        }

        public AutorExtendido? ObtenerAutorYLibros(ApplicationDbContext context, string nombre)
        {
            var query =
                from autor in context.Autores

                where autor.Nombre == nombre

                select new AutorExtendido
                {
                    NombreAutor = autor.Nombre,
                    LibrosEscritos = context.Libros.Where(libro => libro.AutorId == autor.Id).Count()
                };

            return query.FirstOrDefault();
        }
    }
}
