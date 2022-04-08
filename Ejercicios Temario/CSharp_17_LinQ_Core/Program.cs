using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_17_LinQ_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqEjercicios linqEjercicios = new LinqEjercicios();

            //linqEjercicios.Linq1();

            //linqEjercicios.Linq2();

            //linqEjercicios.Linq3();

            linqEjercicios.Linq4();

            // linqEjercicios.Linq5();
        }
    }

    class LinqEjercicios
    {
        readonly List<Alumno> estudiantes = Alumno.GetAlumnos();
        readonly List<Clase> clases = Clase.GetClases();

        /// <summary>
        /// Las tres partes de una operación de consulta:
        /// </summary>
        public void Linq1()
        {
            // 1. Obtener el origen de datos.
            int[] numeros = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Crear la consulta.
            var numQuery =
                from num in numeros
                where num >= 2
                select num;

            // 3. Ejecutar la consulta
            List<int> resultado = numQuery.ToList();
           
        }

        /// <summary>
        /// Iniciar una consulta con la cláusula From
        /// </summary>
        public void Linq2()
        {
            // From
            var alumnosInicialA = from alumno in estudiantes
                                  where alumno.Nombre.StartsWith("A")
                                  select alumno;

            var alumnosInicialALambda = estudiantes.Where(x => x.Nombre.StartsWith("A"));

            foreach (var item in alumnosInicialA)
                Console.WriteLine(item.Nombre);

            // Cláusulas From compuestas
            var notasMasAltas = from estudiante in estudiantes
                                from nota in estudiante.Notas
                                where nota > 8
                                select new { Last = estudiante.Nombre, nota };

            foreach (var item in notasMasAltas)
                Console.WriteLine("{0} Puntuacion: {1}", item.Last, item.nota);

        }

        /// <summary>
        /// Finalizar una consulta con Group y Select
        /// </summary>
        public void Linq3()
        {
            // Group
            var anyosAlumnosGroups = from estudiante in estudiantes
                                     group estudiante by estudiante.FechaDeNacimiento.Year;

            foreach (IGrouping<int, Alumno> itemGroup in anyosAlumnosGroups)
            {
                Console.WriteLine(itemGroup.Key);
                foreach (var item in itemGroup)
                {
                    Console.WriteLine("   {0}, {1}", item.Nombre, item.FechaDeNacimiento.ToString("MM/dd/yyyy"));
                }
            }

            // Select
            var mejorAlumno = from estudiante in estudiantes
                              from nota in estudiante.Notas
                              where nota == 10
                              select estudiante.Nombre;

            foreach (var item in mejorAlumno)
                Console.WriteLine(item);

        }

        /// <summary>
        /// Filtrar, ordenar y combinar consultas con Join, Into, Let, Where y OrderBy
        /// </summary>
        public void Linq4()
        {
            // Join
            var alumnosClase = from e in estudiantes
                               join c in clases on e.Clase equals c.Numero
                               select new
                               {
                                   Clase = c.Nombre,
                                   Estudiante = e.Nombre
                               };

            foreach (var item in alumnosClase)
                Console.WriteLine("{0}, pertenece a la clase {1}", item.Estudiante, item.Clase);

            //into
            var alumnosAgrupadosPorClase = from c in clases
                                           join e in estudiantes on c.Numero equals e.Clase into claseGroup
                                           select new
                                           {
                                               c.Nombre,
                                               c.Anyo,
                                               Products = from prod2 in claseGroup
                                                          orderby prod2.Nombre
                                                          select prod2

                                           };

            foreach (var clase in alumnosAgrupadosPorClase)
            {
                Console.WriteLine("Clase {0}, promocion {1}", clase.Nombre.ToString(), clase.Anyo);
                foreach (var item in clase.Products)
                {
                    Console.WriteLine("   {0}, {1}", item.Nombre, item.FechaDeNacimiento.Year);
                }
            }

            // Let
            var notaMediaAgrupada = from e in estudiantes
                                    let avg = (int)e.Notas.Average()
                                    group e by avg into g
                                    select g;

            foreach (var studentGroup in notaMediaAgrupada)
            {
                Console.WriteLine("Estudiantes con una nota media desde {0}", studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}: {1}", student.Nombre, student.Notas.Average());
                }
            }

            // Where
            var alumnosPorInicialesAE = from e in estudiantes
                                        join c in clases on e.Clase equals c.Numero
                                        let initial = e.Nombre[0]
                                        where initial.Equals('A') || initial.Equals('E')
                                        select new
                                        {
                                            Clase = c.Nombre,
                                            Estudiante = e.Nombre,
                                            initial
                                        };

            foreach (var item in alumnosPorInicialesAE)
                Console.WriteLine("{0} - {1}, de la clase {2}", item.initial, item.Estudiante, item.Clase);

            // Orderby 
            var estudiantesOrdenadosPorNombreYNota = from e in estudiantes
                                                     join c in clases on e.Clase equals c.Numero
                                                     let estado = ((int)e.Notas.Average() > 5 ? "suspendidos" : "aprobados")
                                                     let nota = e.Notas.Average()
                                                     orderby e.Nombre descending, nota ascending
                                                     group new
                                                     {
                                                         c.Nombre,
                                                         NombreAlumno = e.Nombre,
                                                         Estado = estado,
                                                         nota
                                                     }
                                                     by estado
                                       into alumnosAgrupados
                                                     select new
                                                     {
                                                         Estado = alumnosAgrupados.Key,
                                                         Valores = alumnosAgrupados
                                                     };

            foreach (var studentGroup in estudiantesOrdenadosPorNombreYNota)
            {
                Console.WriteLine("Estudiantes {0}:", studentGroup.Estado);
                foreach (var student in studentGroup.Valores)
                {
                    Console.WriteLine("   {0}: {1} {2}", student.Nombre, student.NombreAlumno, student.nota);
                }
            }
        }

        /// <summary>
        /// Más operadores matemáticos, concatenación, conversión, elemento, 
        /// </summary>
        public void Linq5()
        {
            // Operadores matemáticos
            var contador = estudiantes.Count();

            var suma = estudiantes.Sum(x => x.Notas.Sum());

            var maximo = estudiantes.Max(x => x.Notas.Max());

            var media = estudiantes.Average(x => x.Notas.Average());

            // Operadores de particiones de datos 
            var tomar = estudiantes.Take(2);

            var saltar = estudiantes.Skip(3);

            var tomarYSlatar = estudiantes.Skip(2).Take(3);

            // Operador de ordenación
            var vuelta = estudiantes.Reverse<Alumno>();

            // Operadores de consulta
            List<Alumno> estudiantesSegundo = Alumno.GetAlumnos();
            var exceptiones = estudiantes.Except(estudiantesSegundo);

            var distintos = estudiantes.Distinct();

            var union = estudiantes.Union(estudiantesSegundo);

            var concatenar = estudiantes.Select(c => c.Nombre).Concat(clases.Select(s => s.Nombre));

            // Operaciones cuantificadoras que devuelven un valor Boolean 
            var alguno = estudiantes.Any();

            var condicionTodos = estudiantes.All(x => x.Notas.Min() <= 3);

            var contiene = estudiantes.Where(x => x.Nombre.Contains("Elisa"));

            // Operaciones de elementos
            var primer = estudiantes.First();

            var primeroPorDefecto = estudiantes.FirstOrDefault();

            var elementoEn = estudiantes.ElementAt(3);

            var ultimo = estudiantes.Last();

            List<Alumno> estudiantesTercero = new List<Alumno> { new Alumno { Nombre = "Elisa", Notas = new List<int> { 2, 8, 5, 9 }, FechaDeNacimiento = new DateTime(2002, 1, 1), Clase = 3 } };
            var unico = estudiantesTercero.Single();

            var unicoPorDefecto = estudiantesTercero.SingleOrDefault();

            // Operadores de conversión
            List<Alumno> listadoDeEstudiantes = estudiantes.ToList();

            Alumno[] arrayDeEstudiantes = estudiantes.ToArray();

            Dictionary<string, int> dictionaryDeEstudiantes = estudiantes.ToDictionary(x => x.Nombre, x => x.Clase);

            IEnumerable<string> castAlumno = estudiantes.Select(x => x.Nombre).Cast<string>();

        }
    }
}
