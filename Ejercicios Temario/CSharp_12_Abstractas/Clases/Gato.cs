using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_12_Abstractas
{
    public class Gato : Animal
    {
        /// <summary>
        /// Implementación del método definido en la calse abstracta.
        /// </summary>
        public override void HacerSonido()
        {
            Console.Write(GetRuido() + ":");
            for (int i = 0; i < 3; i++) Console.Write(" Miau!");
            Console.WriteLine();
        }
    }
}
