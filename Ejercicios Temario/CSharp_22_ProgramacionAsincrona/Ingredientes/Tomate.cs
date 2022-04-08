using System;
using System.Threading.Tasks;

namespace CSharp_22_ProgramacionAsincrona.Ingredientes
{
    public class Tomate
    {
        public Tomate()
        {
        }

        public static implicit operator Task<object>(Tomate v)
        {
            throw new NotImplementedException();
        }
    }
}
