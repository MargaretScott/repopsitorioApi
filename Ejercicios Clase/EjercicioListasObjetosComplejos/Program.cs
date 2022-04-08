using EjercicioListasObjetosComplejos.Entidades;

namespace EjercicioListasObjetosComplejos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> listaPersonas = new List<Persona>
            {
                new Persona
                {
                    Id = 1,
                    Nombre = "Pedro",
                    Apellidos = "Sanchez",
                    Email = "pedro.sanchez@codehouse.academy"
                },
                new Persona
                {
                    Id = 2,
                    Nombre = "Lorena",
                    Apellidos = "Asensio",
                    Email = "lorena.asensio@codehouse.academy"
                }
            };

            Persona personaNueva = new Persona();
            personaNueva.Id = 3;
            personaNueva.Nombre = "Margaret";
            personaNueva.Apellidos = "Scott";
            personaNueva.Email = "margaret.scott@codehouse.academy";

            listaPersonas.Add(personaNueva);

            foreach(Persona persona in listaPersonas)
            {
                Console.WriteLine(persona.Nombre + " " + persona.Apellidos);
            }

        }
    }
}
