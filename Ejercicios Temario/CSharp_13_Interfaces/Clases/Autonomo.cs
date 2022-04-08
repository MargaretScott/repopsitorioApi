using System;
using CSharp_13_Interfaces.Interfaces;

namespace CSharp_13_Interfaces
{
    /// <summary>
    /// Una clase puede heredar de varias interfaces pero solo de una clase.
    /// </summary>
    public class Autonomo : Persona, ITrabajador, IComercial, IFinanciero
    {
        #region PROPIEDADES

        /// <summary>
        /// Propiedad de ITrabajador.
        /// </summary>
        public string Profesion { get; set; }

        /// <summary>
        /// Propiedad de IComercial.
        /// </summary>
        public int NumeroVentas { get; set; }

        /// <summary>
        /// Propiedad de IFinanciero.
        /// </summary>
        public int Ingresos { get; set; }

        /// <summary>
        /// Propiedad de IFinanciero.
        /// </summary>
        public int Gastos { get; set; }

        /// <summary>
        /// Propiedad de solo lectura de la clase Autonomo.
        /// </summary>
        public bool PuedeConTodo =>
            !Profesion.Equals(string.Empty) && 
            NumeroVentas > 0 && 
            Ingresos > (2 * Gastos);

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor de objetos de la clase Autonomo.
        /// </summary>
        /// <param name="nombre">Propiedad heredada de Persona.</param>
        public Autonomo(string nombre = "Anónimo")
        {
            Nombre = nombre;
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Método de IComercial.
        /// </summary>
        public void ConseguirClientes()
        {
            Console.WriteLine(Nombre + " busca sus clientes...");
        }

        /// <summary>
        /// Método de IFinanciero.
        /// </summary>
        public void LlevarContabilidad()
        {
            Console.WriteLine(Nombre + " lleva sus cuentas...");
        }

        /// <summary>
        /// Método de ITrabajador.
        /// </summary>
        public void RealizarTareas()
        {
            Console.WriteLine(Nombre + " realiza sus tareas...");
        }

        /// <summary>
        /// Método propio de la clase Autonomo
        /// </summary>
        public void PagarCuotas()
        {
            Console.WriteLine(Nombre + " paga sus cuotas...");
        }

        #endregion
    }
}
