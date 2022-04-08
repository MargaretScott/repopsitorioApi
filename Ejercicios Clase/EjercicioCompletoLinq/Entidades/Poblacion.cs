namespace EjercicioCompletoLinq.Entidades
{
    public class Poblacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Poblacion> GetPoblaciones()
        {
            return new List<Poblacion>
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
        }
    }
}
