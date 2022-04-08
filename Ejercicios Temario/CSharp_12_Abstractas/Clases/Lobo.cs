using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_12_Abstractas
{
    public class Lobo : Animal
    {
        /// <summary>
        /// Implementación del método definido en la calse abstracta.
        /// </summary>
        public override void HacerSonido()
        {
            Console.WriteLine(GetRuido() + ": AuuUUuuUuuuuuUUU!");
        }
    }
}
