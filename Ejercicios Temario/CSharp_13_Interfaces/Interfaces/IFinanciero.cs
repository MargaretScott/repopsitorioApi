using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_13_Interfaces.Interfaces
{
    interface IFinanciero
    {
        int Ingresos { get; set; }
        int Gastos { get; set; }

        /// <summary>
        /// Contrato para la implementación del método.
        /// </summary>
        void LlevarContabilidad();
    }
}
