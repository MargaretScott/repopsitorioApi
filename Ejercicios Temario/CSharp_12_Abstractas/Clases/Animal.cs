using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_12_Abstractas
{
    /// <summary>
    /// Una clase abstracta puede heredar de otra clase.
    /// </summary>
    public abstract class Animal : SerVivo
    {
        /// <summary>
        /// Propiedad privada que heredan las clases derivadas.
        /// </summary>
        private string _ruido;

        /// <summary>
        /// Método público que permite cambiar la propiedad privada.
        /// </summary>
        /// <param name="sonido">Ruido que hace el animal.</param>
        public void SetRuido(string ruido)
        {
            _ruido = ruido;
        }

        /// <summary>
        /// Acceso protegido al valor de la propiedad privada.
        /// </summary>
        /// <returns></returns>
        protected string GetRuido()
        {
            return _ruido;
        }

        /// <summary>
        /// Métodos definido pero no implementado.
        /// </summary>
        public abstract void HacerSonido();
    }
}
