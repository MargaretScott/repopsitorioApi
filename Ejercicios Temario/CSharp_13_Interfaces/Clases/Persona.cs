using CSharp_13_Interfaces.Interfaces;
using System;

namespace CSharp_13_Interfaces
{
    public class Persona : IPersona
    {
        public string Nombre { get; set; }

        public void SerFeliz()
        {
            Console.WriteLine(Nombre + " intenta ser feliz...");
        }
    }
}
