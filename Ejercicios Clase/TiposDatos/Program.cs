using System;

namespace CSharp_01_TiposDato
{
    class Program
    {
        struct Coordinate
        {
            public int x;
            public int y;
        }

        enum EstadoCivil
        {
            Soltero = 1,
            Casado = 2,
            Divorciado = 3,
            Viudo = 4
        }

        static void Main(string[] args)
        {

            // Número entero de 0 a 255
            byte tipoByte = 200;
            Console.WriteLine("byte: " + tipoByte);

            // Número entero de -128 a 127
            sbyte tipoSByte = -100;
            Console.WriteLine("sbyte: " + tipoSByte);

            // Número entero de -32768 a 32767
            short tipoShort = -30000;
            Console.WriteLine("short: " + tipoShort);

            // Número entero de 0 a 65535
            ushort tipoUShort = 50;
            Console.WriteLine("ushort: " + tipoUShort);

            // Número entero de –2147483648 a 2147483647
            int tipoInt = -2000000000;
            Console.WriteLine("int: " + tipoInt);

            // Número entero de 0 a 4294967295
            uint tipoUInt = 2000000000;
            Console.WriteLine("uint: " + tipoUInt);

            // Número entero de –9223372036854775808 a 9223372036854775807
            long tipoLong = -1000000000000000000;
            Console.WriteLine("long: " + tipoLong);

            // Número entero de 0 a 18446744073709551615
            ulong tipoULong = 1000000000000000000;
            Console.WriteLine("ulong: " + tipoULong);

            // Número decimal de -79228162514264337593543950335 a 79228162514264337593543950335
            decimal tipoDecimal = 0.999999999999M;
            Console.WriteLine("decimal: " + tipoDecimal);

            // Número decimal de -1,79769313486232E+308 a 1,79769313486232E+308
            double tipoDouble = 1000000.666D;
            Console.WriteLine("double: " + tipoDouble);

            // Número decimal de -3,402823E+38 a 3,402823E+38
            float tipoFloat = 1000.333F;
            Console.WriteLine("float: " + tipoFloat);

            // Único caracter
            char tipoChar = 'a';
            Console.WriteLine("char: " + tipoChar);

            // Cadena de caracteres
            string tipoString = "Cadena";
            Console.WriteLine("string: " + tipoString);

            // Valor booleano, verdadero o falso
            bool tipoBool = false;
            Console.WriteLine("bool : " + tipoBool);

            // Tipo objeto
            object tipoObject = 123456;
            Console.WriteLine("object: " + tipoObject);

            // Tipo dinámico
            dynamic tipoDynamic = 123;
            Console.WriteLine("dynamic: " + tipoDynamic);
            tipoDynamic = "abc";
            Console.WriteLine("dynamic: " + tipoDynamic);

            // Matrices o Arrays: tipo[]

            bool[] arrayBool = new bool[5];
            arrayBool[0] = true;
            Console.WriteLine("arrayBool[0]: " + arrayBool[0]);

            char[] arrayChar = { 'a', 'b', 'c', 'd' };
            Console.WriteLine("arrayChar[2]: " + arrayChar[2]);

            string[] arrayString = new string[3];
            Console.WriteLine("arrayString[0]: " + arrayString[0]);

            float[,] arrayFloat = new float[2, 2];
            Console.WriteLine("arrayFloat[0,0]: " + arrayFloat[0, 0]);

            int[,] arrayInt = { { 2, 5 }, { 3, 6 } };
            Console.WriteLine("arrayInt[1,0]: " + arrayInt[1, 0]);

            int[][] arrayEscalonado = new int[3][];
            arrayEscalonado[0] = new int[4] { 3, 6, 7, 2 };
            arrayEscalonado[1] = new int[2] { 1, 4 };
            arrayEscalonado[2] = new int[3] { 5, 8, 9 };
            Console.WriteLine("arrayEscalonado[1][0]: " + arrayEscalonado[1][0]);


            Coordinate a;
            a.x = 2;
            a.y = 5;

        }
    }
}
