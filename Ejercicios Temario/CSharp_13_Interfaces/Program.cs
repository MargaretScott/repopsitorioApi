using System;

namespace CSharp_13_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Autonomo autonomo = new Autonomo();

            autonomo.Profesion = "desarrollador"; // Propiedad de ITrabajador.
            autonomo.NumeroVentas = 5; // Propiedad de IComercial.
            autonomo.Ingresos = 4000; // Propiedad de IFinanciero.
            autonomo.Gastos = 1500; // Propiedad de IFinanciero.

            autonomo.PagarCuotas(); // Método de Autonomo.
            autonomo.ConseguirClientes(); // Método de IComercial.
            autonomo.RealizarTareas(); // Método de ITrabajador.
            autonomo.LlevarContabilidad(); // Método de IFinanciero.
            autonomo.SerFeliz(); // Método de Persona.

            // Propiedad de Autonomo.
            if (autonomo.PuedeConTodo) Console.WriteLine(autonomo.Nombre + " es un superhéroe!");
            else Console.WriteLine("Mucho ánimo, " + autonomo.Nombre + "!");
        }
    }
}
