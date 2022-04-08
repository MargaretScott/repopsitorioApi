using System;

namespace CSharp_03_ConversionTipos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conversión implícita
            int numeroEntero = 34543;
            Console.WriteLine("numeroEntero: " + numeroEntero);
            long numeroLong = numeroEntero;
            Console.WriteLine("numeroLong: " + numeroLong);

            // Conversión explícita
            double numeroDouble = 12.56;
            Console.WriteLine("numeroDouble: " + numeroDouble);
            int numeroInt = (int)numeroDouble;
            Console.WriteLine("numeroInt: " + numeroInt);

            // Otras conversiones
            float numeroFloat = 25.39F;
            Console.WriteLine("numeroFloat: " + numeroFloat);
            string cadenaString = numeroFloat.ToString();
            Console.WriteLine("cadenaString: " + cadenaString);

            // Boxing y Unboxing

            int numero = 123;
            Console.WriteLine("numero (valor): " + numero);
            object objeto = numero; // Boxing
            Console.WriteLine("objeto (copia): " + objeto);
            numero = 456;
            Console.WriteLine("numero: " + numero);
            Console.WriteLine("objeto: " + objeto);

            string cadena = "hola";
            Console.WriteLine("string (valor): " + cadena);
            object objetoBoxing = cadena; // Boxing (de tipo a object)
            Console.WriteLine("objetoBoxing: " + objetoBoxing);
            string cadenaUnboxing = (string)objetoBoxing; // Unboxing (de object a tipo)
            Console.WriteLine("cadenaUnboxing: " + cadenaUnboxing);

            // Ejemplo de uso en matriz o array de tipo object:
            char ejChar = 'a';
            int ejInt = 123;
            string ejString = "hola";
            double ejDouble = 4.56;
            bool ejBool = false;

            object[] mezcla = new object[5];
            Console.WriteLine("mezcla (" + mezcla.GetType() + ")");

            mezcla[0] = ejChar; // Boxing desde char
            mezcla[1] = ejInt; // Boxing desde int
            mezcla[2] = ejString; // Boxing desde string
            mezcla[3] = ejDouble; // Boxing desde double
            mezcla[4] = ejBool; // Boxing desde bool
            Console.WriteLine("mezcla[0] (" + mezcla[0].GetType() + "): " + mezcla[0]);
            Console.WriteLine("mezcla[1] (" + mezcla[1].GetType() + "): " + mezcla[1]);
            Console.WriteLine("mezcla[2] (" + mezcla[2].GetType() + "): " + mezcla[2]);
            Console.WriteLine("mezcla[3] (" + mezcla[3].GetType() + "): " + mezcla[3]);
            Console.WriteLine("mezcla[4] (" + mezcla[4].GetType() + "): " + mezcla[4]);
        }
    }
}
