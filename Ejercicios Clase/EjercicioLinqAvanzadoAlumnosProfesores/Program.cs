using EjercicioLinqAvanzadoAlumnosProfesores.Entidades;

namespace EjercicioLinqAvanzadoAlumnosProfesores
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear una lista de poblaciones
            List<Poblacion> listaPoblaciones = new List<Poblacion>()
            {
                new Poblacion
                {
                    Id = 1,
                    Nombre = "Madrid"
                },
                new Poblacion
                {
                    Id = 2,
                    Nombre = "Barcelona"
                },
                new Poblacion
                {
                    Id = 3,
                    Nombre = "Valencia"
                }
            };

            //Crear lista de 4 alumnos
            List<Alumno> listaAlumnos = new List<Alumno>
            {
                new Alumno
                {
                    Nombre = "Pepe",
                    Apellidos = "Garcia",
                    Edad = 25,  
                    Clase = ".NET",
                    PoblacionId = 2
                },
                new Alumno
                {
                    Nombre = "Jose",
                    Apellidos = "Perez",
                    Edad = 27,
                    Clase = "Angular",
                    PoblacionId = 2
                }
            };

            listaAlumnos.Add(
                new Alumno
                {
                    Nombre = "Pepa",
                    Apellidos = "Sanchez",
                    Edad = 21,
                    Clase = "Angular",
                    PoblacionId = 3
                }
            );

            List<Alumno> listaAlumnos2 = new List<Alumno>
            {
                new Alumno
                {
                    Nombre = "Inma",
                    Apellidos = "Sanchez",
                    Edad = 25,
                    Clase = ".NET",
                    PoblacionId = 2
                }
            };

            listaAlumnos.AddRange(listaAlumnos2);

            //Crear lista de 4 profesores
            List<Profesor> listaProfesores = new List<Profesor>
            {
                new Profesor
                {
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    Edad = 40,
                    Asignatura = ".NET",
                    PoblacionId = 2
                },
                new Profesor
                {
                    Nombre = "Rafael",
                    Apellidos = "Escalante",
                    Edad = 37,
                    Asignatura = "Angular",
                    PoblacionId = 1
                },
                new Profesor
                {
                    Nombre = "Ruben",
                    Apellidos = "Garcia",
                    Edad = 38,
                    Asignatura = ".NET",
                    PoblacionId = 3
                },
                new Profesor
                {
                    Nombre = "Laura",
                    Apellidos = "Martinez",
                    Edad = 41,
                    Asignatura = ".NET",
                    PoblacionId = 2
                }
            };

            //Formato Query
            var queryAlumnos =
                from alu in listaAlumnos
                where alu.Edad >= 25
                   && alu.Clase == ".NET"
                select new AlumnoExtendido
                {
                    Nombre = alu.Nombre,
                    Apellidos = alu.Apellidos,
                    Edad = alu.Edad,
                    Clase = alu.Clase,
                    Nota = 9
                };

            var queryAlumnosLambda =
                listaAlumnos
                .Where(alu => alu.Edad >= 25
                   && alu.Clase == ".NET")
                .Select(alu => new AlumnoExtendido
                {
                    Nombre = alu.Nombre,
                    Apellidos = alu.Apellidos,
                    Edad = alu.Edad,
                    Clase = alu.Clase,
                    Nota = 9
                });

            List<AlumnoExtendido> alumnosFiltrados = queryAlumnosLambda.ToList();

            if (alumnosFiltrados == null || alumnosFiltrados.Count == 0)
            {
                Console.WriteLine("La query alumnos no devuelve resultados");
            }
            else
            {
                foreach (AlumnoExtendido alumno in alumnosFiltrados)
                {
                    Console.WriteLine(alumno.Nombre);
                }
            }

            //-------------Query Profesores------------
            var queryProfesores =
                from prof in listaProfesores
                where prof.Edad >= 40
                   && prof.Asignatura == ".NET"
                select new ProfesorExtendido
                {
                    Nombre = prof.Nombre,
                    Apellidos = prof.Apellidos,
                    Edad = prof.Edad,
                    Asignatura = prof.Asignatura,
                    Evaluacion = 10
                };

            List<ProfesorExtendido> profesoresFiltrados = queryProfesores.ToList();


            foreach(ProfesorExtendido profesor in profesoresFiltrados)
            {
                Console.WriteLine(profesor.Nombre);
            }

            var queryAlumnosPorInicioDeNombre =
               from alu in listaAlumnos
               where alu.Nombre.StartsWith("P")
               select new AlumnoExtendido
               {
                   Nombre = alu.Nombre,
                   Apellidos = alu.Apellidos,
                   Edad = alu.Edad,
                   Clase = alu.Clase,
                   Nota = 9
               };

            List<AlumnoExtendido> alumnosFiltrados2 = queryAlumnosPorInicioDeNombre.ToList();

            Console.WriteLine("----------------Query StartsWith---------------");

            if (alumnosFiltrados2 == null || alumnosFiltrados2.Any())
            {
                Console.WriteLine("La query alumnos no devuelve resultados");
            }
            else
            {
                foreach (AlumnoExtendido alumno in alumnosFiltrados2)
                {
                    Console.WriteLine(alumno.Nombre);
                }
            }

            var queryProfesores2 =
                from prof in listaProfesores
                where prof.Nombre.Contains("Ju")
                select new ProfesorExtendido
                {
                    Nombre = prof.Nombre,
                    Apellidos = prof.Apellidos,
                    Edad = prof.Edad,
                    Asignatura = prof.Asignatura,
                    Evaluacion = 10
                };

            List<ProfesorExtendido> profesoresFiltrados2 = queryProfesores2.ToList();

            Console.WriteLine("----------------Query Contains---------------");

            foreach (ProfesorExtendido profesor in profesoresFiltrados2)
            {
                Console.WriteLine(profesor.Nombre);
            }

            var queryAlumnosJoin =
                from alu in listaAlumnos
                join pob in listaPoblaciones on alu.PoblacionId equals pob.Id
                where pob.Nombre == "Barcelona"
                orderby alu.Edad descending, alu.Nombre ascending
                select new AlumnoExtendido
                {
                    Nombre = alu.Nombre,
                    Apellidos = alu.Apellidos,
                    Edad = alu.Edad,
                    Clase = alu.Clase,
                    Nota = 9,
                    PoblacionId = alu.PoblacionId,
                    NombrePoblacion = pob.Nombre
                };

            List<AlumnoExtendido> alumnosConJoin = queryAlumnosJoin.ToList();

            int total = alumnosConJoin.Count();

            //Pagina 1 en paginas de tamaño 2
            int pagina = 2;
            int numeroResgitrosPorPagina = 2;

            int skip = (pagina - 1) * numeroResgitrosPorPagina;
            int take = numeroResgitrosPorPagina;

            List<AlumnoExtendido> alumnosPaginados = alumnosConJoin.Skip(skip).Take(take).ToList();

            foreach (AlumnoExtendido alumno in alumnosPaginados)
            {
                Console.WriteLine($"El alumno {alumno.Nombre} vive en {alumno.NombrePoblacion} y tiene {alumno.Edad}");
            }
        }

    }

}
