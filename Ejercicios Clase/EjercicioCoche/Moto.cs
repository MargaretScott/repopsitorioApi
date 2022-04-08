using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCoche
{
    public class Moto : Vehiculo
    {
        public string ModeloCasco { get; set; }


        public void Saludar()
        {
            Console.WriteLine("Hola!!");
        }
    }
}
