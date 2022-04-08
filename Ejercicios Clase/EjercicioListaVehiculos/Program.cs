using EjercicioListaVehiculos.Entidades;

namespace EjercicioListaVehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Coche> listaCoches = new List<Coche>
            {
                new Coche
                {
                    Id = 1,
                    Marca = "Renault",
                    Combustible = "Gasolina",
                    NumeroPuertas = 5
                },
                new Coche
                {
                    Id = 2,
                    Marca = "Seat",
                    Combustible = "Gasoil",
                    NumeroPuertas = 3
                },
                new Coche
                {
                    Id = 3,
                    Marca = "Peugeot",
                    Combustible = "Electrico",
                    NumeroPuertas = 5
                }
            };

            List<Camion> listaCamiones = new List<Camion>
            {
                new Camion
                {
                    Id = 1,
                    Marca = "Mercedes",
                    Combustible = "Gasolina",
                    CargaMaxima = 5000
                },
                new Camion
                {
                    Id = 2,
                    Marca = "Iveco",
                    Combustible = "Gasoil",
                    CargaMaxima = 7000
                }
            };

            listaCoches.Add(
                new Coche
                {
                    Id = 4,
                    Marca = "BMW",
                    Combustible = "Gasolina",
                    NumeroPuertas = 5
                }
            );

            listaCoches.RemoveAt(2);

            Console.WriteLine("Lista de Coches ----------------");

            foreach (Coche coche in listaCoches)
            {
                Console.WriteLine($"{coche.Marca} de {coche.Combustible} con {coche.NumeroPuertas} puertas");
            }

            List<Camion> listaCamiones2 = new List<Camion>
            {
                new Camion
                {
                    Id = 3,
                    Marca = "Renault",
                    Combustible = "Gasolina",
                    CargaMaxima = 5000
                },
                new Camion
                {
                    Id = 4,
                    Marca = "Seat",
                    Combustible = "Gasoil",
                    CargaMaxima = 7000
                }
            };

            listaCamiones.AddRange(listaCamiones2);

            Console.WriteLine("Lista de Camiones ----------------");

            foreach (Camion camion in listaCamiones)
            {
                Console.WriteLine($"{camion.Marca} de {camion.Combustible} con {camion.CargaMaxima} de carga maxima");
            }


            //---------------Linq Listado-----------------
            var query =
                from cam in listaCamiones
                where cam.CargaMaxima == 5000
                select cam;

            List<Camion> resultadoLinq = query.ToList();

            foreach (Camion camion in resultadoLinq)
            {
                Console.WriteLine($"{camion.Marca} de {camion.Combustible} con {camion.CargaMaxima} de carga maxima");
            }

            //----------Linq First------------
            var queryFirst =
                from cam in listaCamiones
                where cam.Id == 1
                select cam;

            Camion camionFiltrado = queryFirst.First();

            Console.WriteLine("El coche filtrado es " + camionFiltrado.Marca);


            //-----------Linq Proyectada a objeto---------
            var queryProyectada =
                 from coch in listaCoches
                 where coch.NumeroPuertas > 2
                    && coch.NumeroPuertas < 5
                    && coch.Marca == "Seat"
                 select new CocheExtendido
                 {
                     Id = coch.Id,
                     Marca = coch.Marca,
                     Combustible = coch.Combustible,
                     NumeroPuertas = coch.NumeroPuertas,
                     FechaQuery = DateTime.Now
                 };

            List<CocheExtendido> cochesProyectados =  queryProyectada.ToList();

            foreach (CocheExtendido coche in cochesProyectados)
            {
                Console.WriteLine($"{coche.Marca} de {coche.Combustible} con {coche.NumeroPuertas} de puertas y la query fue ejecutada en esta fecha {coche.FechaQuery}");
            }
        }

    }

}
