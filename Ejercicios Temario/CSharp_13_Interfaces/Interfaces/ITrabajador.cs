using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_13_Interfaces.Interfaces
{
    interface ITrabajador
    {
        string Profesion { get; set; }

        /// <summary>
        /// Contrato para la implementación del método.
        /// </summary>
        void RealizarTareas();
    }
}
