namespace EjercicioCompletoLinq.Entidades
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public List<int> Notas { get; set; }
        public int Clase { get; set; }
        public int PoblacionId { get; set; }

        public static List<Alumno> GetAlumnos()
        {
            return new List<Alumno>
            {
                new Alumno 
                { 
                    Nombre = "Elisa",
                    Notas = new List<int> { 2, 8, 5, 9 },
                    FechaDeNacimiento = new DateTime(2002,1,1),   
                    Clase=3,
                    PoblacionId = 1
                },
                new Alumno { Nombre = "Flor", Notas = new List<int> { 6, 2, 6, 5 },FechaDeNacimiento = new DateTime(2003,11,21), Clase=4,PoblacionId=1 },
                new Alumno { Nombre = "Ricardo", Notas = new List<int> { 10, 8, 6, 3 },FechaDeNacimiento = new DateTime(2002, 12, 8), Clase=3,PoblacionId=2 },
                new Alumno { Nombre = "Aitor", Notas = new List<int> { 6, 7, 4, 5 },FechaDeNacimiento = new DateTime(2001,2,10), Clase=2,PoblacionId=3 },
                new Alumno { Nombre = "Antonio", Notas = new List<int> { 6, 7, 4, 5 },FechaDeNacimiento = new DateTime(2001,2,10), Clase=2,PoblacionId=2 },
                new Alumno { Nombre = "Rebeca", Notas = new List<int> { 2, 8, 5, 9 }, FechaDeNacimiento = new DateTime(2002,1,1), Clase=3,PoblacionId=1 },
                new Alumno { Nombre = "Flavio", Notas = new List<int> { 8, 9, 5, 8 },FechaDeNacimiento = new DateTime(2001,8,28), Clase=2,PoblacionId=3 },
                new Alumno { Nombre = "Ruben", Notas = new List<int> { 7, 9, 4, 8 },FechaDeNacimiento = new DateTime(2006,8,28), Clase=2,PoblacionId=2 }
            };
        }
    }
}
