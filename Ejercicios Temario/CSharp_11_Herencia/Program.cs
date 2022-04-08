using System;

namespace CSharp_11_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia de la clase padre.
            Vehiculo vehiculo = new Vehiculo
            {
                Matricula = 123
            };

            // Instancia de una clase derivada de Vehiculo.
            DePasajeros vehiculoPasajeros = new DePasajeros
            {
                Matricula = 234,
                NumeroPasajeros = 10
            };

            // DeTransporte es una extensión de Vehículo.
            Vehiculo vehiculoTransporte = new DeTransporte
            {
                Matricula = 345,
                CargaMaxima = 6000
            };

            // Instancia de una clase derivada de DePasajeros.
            Coche coche = new Coche
            {
                Matricula = 456,
                NumeroPasajeros = 5,
                NumeroPuertas = 4
            };

            // Camion es una extensión de DeTransporte que hereda de Vehiculo.
            DeTransporte camion = new Camion
            {
                Matricula = 567,
                CargaMaxima = 3000,
                NumeroEjes = 8
            };

            // Bicicleta hereda de Vehiculo porque extiende a DePasajeros.
            Vehiculo bicicleta = new Bicicleta
            {
                Matricula = 678,
                NumeroPasajeros = 1,
                Velocidades = 18
            };

            /*
             * Podemos hacer esto porque todos los objetos son instancias de
             *      Vehiculo, 
             *      una clase que hereda de Vehiculo o 
             *      una extensión de una clase que hereda de Vehiculo.
             */
            Vehiculo[] vehiculos = { vehiculo, vehiculoPasajeros, vehiculoTransporte, coche, camion, bicicleta };


            foreach (var objeto in vehiculos)
            {
                // Todos los objetos tienes la propiedad Matricula porque la heredan de Vehículo.
                Console.WriteLine("Matrícula " + objeto.Matricula + " --> " + objeto.GetType());
            }
        }
    }
}
