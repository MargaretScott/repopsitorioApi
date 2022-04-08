namespace EjercicioCompletoLinq.Entidades
{
    public class Profesor
    {
        public string Nombre { get; set; }
        public int Clase { get; set; }
        public int PoblacionId { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        public static List<Profesor> GetProfesores()
        {
            return new List<Profesor>
            {
                new Profesor
                {
                    Nombre = "Juana",
                    FechaDeNacimiento = new DateTime(2002,1,1),
                    Clase=3,
                    PoblacionId=1
                },
                new Profesor { Nombre = "Flor",FechaDeNacimiento = new DateTime(2003,11,21), Clase=4,PoblacionId=2 },
                new Profesor { Nombre = "Ricardo",FechaDeNacimiento = new DateTime(2002, 12, 8), Clase=3,PoblacionId=3 },
                new Profesor { Nombre = "Aitor",FechaDeNacimiento = new DateTime(2001,2,10), Clase=2,PoblacionId=1 },
                new Profesor { Nombre = "Antonio",FechaDeNacimiento = new DateTime(2001,2,10), Clase=2,PoblacionId=2 },
                new Profesor { Nombre = "Rebeca", FechaDeNacimiento = new DateTime(2002,1,1), Clase=3,PoblacionId=3 },
                new Profesor { Nombre = "Flavio",FechaDeNacimiento = new DateTime(2001,8,28), Clase=2,PoblacionId=2 },
                new Profesor { Nombre = "Ruben",FechaDeNacimiento = new DateTime(2006,8,28), Clase=2,PoblacionId=1 }
            };
        }
    }
}
