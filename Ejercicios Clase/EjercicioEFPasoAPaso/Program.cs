using EjercicioEFPasoAPaso.AccesoDatos;
using EjercicioEFPasoAPaso.AccesoDatos.Clases;
using EjercicioEFPasoAPaso.AccesoDatos.Entidades;

namespace EjercicioEFPasoAPaso
{
    class Program
    {
        static void Main(string[] args)
        {
            MetodosAutor metodosAutor = new MetodosAutor();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //InsertarDatos();
                //BorrarLibro("El guardián entre el centeno");
                //BorrarAutor("J. D. Salinger");
                //ActualizarLibro("Prueba");
                AutorExtendido? autor = metodosAutor.ObtenerAutorYLibros(context, "J. R. R. Tolkien");

                Console.WriteLine($"El autor {autor.NombreAutor} ha escrito {autor.LibrosEscritos} libros.");
            }
        }

        public static void InsertarDatos()
        {
            MetodosAutor metodosAutor = new MetodosAutor();
            MetodosLibro metodosLibro = new MetodosLibro();

            List<Autor> autores = metodosAutor.ObtenerListadoLocalEjemplo();
            List<Libro> libros = metodosLibro.ObtenerListadoLocalEjemplo();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                foreach(Autor autor in autores)
                {
                    metodosAutor.InsertarDatos(context, autor);
                }

                foreach (Libro libro in libros)
                {
                    metodosLibro.InsertarDatos(context, libro);
                }

                context.SaveChanges();
            }
        }

        public static void BorrarAutor(string nombre)
        {
            MetodosAutor metodosAutor = new MetodosAutor();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Autor? autorABorrar = metodosAutor.ObtenerAutorPorNombre(context, nombre);

                if(autorABorrar == null)
                {
                    Console.WriteLine("El autor no existe");
                }
                else
                {
                    metodosAutor.BorrarDatos(context, autorABorrar.Id);

                    context.SaveChanges();
                }

            }
        }

        public static void BorrarLibro(string titulo)
        {
            MetodosLibro metodosLibro = new MetodosLibro();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Libro? libroABorrar = metodosLibro.ObtenerLibroPorTitulo(context, titulo);

                if (libroABorrar == null)
                {
                    Console.WriteLine("El libro no existe");
                }
                else
                {
                    metodosLibro.BorrarDatos(context, libroABorrar.Id);

                    context.SaveChanges();
                }

            }
        }

        public static void ActualizarLibro(string titulo)
        {
            MetodosLibro metodosLibro = new MetodosLibro();

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Libro libroAActualizar = new Libro { Titulo = titulo };

                metodosLibro.ActualizarDatos(context, libroAActualizar, 7);

                context.SaveChanges();
            }
        }

    }
}
