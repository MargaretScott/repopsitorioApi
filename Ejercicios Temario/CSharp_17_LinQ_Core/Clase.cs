using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_17_LinQ_Core
{
    public class Clase
    {
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public int Anyo { get; set; }

        public static List<Clase> GetClases()
        {
            return new List<Clase>
            {
                new Clase { Anyo = 2000, Numero=1, Nombre="Ken Thompson"},
                new Clase { Anyo = 2001, Numero=2, Nombre="Maria Zambrano"},
                new Clase { Anyo = 2002, Numero=3, Nombre="Dennis Ritchie"},
                new Clase { Anyo = 2003, Numero=4, Nombre="Ada Lovelace"}
            };
        }
    }
}
