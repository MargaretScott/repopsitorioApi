using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_12_Abstractas
{
    public class Vaca : Animal
    {
        /// <summary>
        /// Implementación del método definido en la calse abstracta.
        /// </summary>
        public override void HacerSonido()
        {
            string nombreSonido = GetRuido();
            Console.WriteLine("{0}: MuuuuUU! MuuuuUU!", nombreSonido);
        }
    }
}
