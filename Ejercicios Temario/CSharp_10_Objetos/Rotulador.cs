using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_10_Objetos
{
    class Rotulador
    {
        #region PROPIEDADES

        /// <summary>
        /// Indica el color de la tinta del rotulador.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Indica el grosor de la punta del rotulador.
        /// </summary>
        public double Grosor { get; set; }

        /// <summary>
        /// Indica si el rotulador es o no permatente.
        /// </summary>
        public bool Permanente { get; set; }

        /// <summary>
        /// Indica el nivel de tinta restante del rotulador.
        /// </summary>
        public int NivelTinta { get; set; }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto o sin parámetros de objetos "Rotulador".
        /// </summary>
        public Rotulador()
        {
            NivelTinta = 100;
        }

        /// <summary>
        /// Costructos con parámetros de objetos "Rotulador".
        /// </summary>
        /// <param name="color"></param>
        /// <param name="grosor"></param>
        /// <param name="permanente"></param>
        /// <param name="nivel"></param>
        public Rotulador(string color, double grosor, bool permanente, int nivel = 100)
        {
            Color = color;
            Grosor = grosor;
            Permanente = permanente;
            NivelTinta = nivel;
        }


        #endregion

        #region MÉTODOS

        /// <summary>
        /// Método de tipo procedimiento porque no devuelve ningún valor.
        /// Actualiza el nivel de tinta después de pintar un dibujo.
        /// </summary>
        /// <param name="cantidad">Cantidad de dibujo que se va a pintar.</param>
        public void Pintar(int cantidad)
        {
            int tintaGastada = 1 + (int)(cantidad * Grosor);
            Console.WriteLine("rotulador pintando......... " + tintaGastada);
            NivelTinta -= tintaGastada;
        }

        /// <summary>
        /// Método de tipo función porque devuelve un valor.
        /// </summary>
        /// <returns>Devuelve si al rotulador le queda tinta o no.</returns>
        public bool TieneTinta()
        {
            return NivelTinta > 0;
        }

        # endregion
    }
}
