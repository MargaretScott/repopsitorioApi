using System;
using System.Text;

namespace CSharp_14_Cadenas_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadenaA = "primera";
            String cadenaB = "segunda";
            var cadenaC = "tercera";

            Console.WriteLine(cadenaA + ", " + cadenaB + " y " + cadenaC + ".");
            Console.WriteLine("{0}, {1} y {2}.", cadenaA, cadenaB, cadenaC);

            string cadenaD = cadenaA + ", " + cadenaB + " y " + cadenaC + ".";
            string cadenaE = $"{cadenaA}, {cadenaB} y {cadenaC}.";
            string cadenaF = string.Concat(cadenaA, ", ", cadenaB, " y ", cadenaC, ".");

            Console.WriteLine(cadenaD);
            Console.WriteLine(cadenaE);
            Console.WriteLine(cadenaF);

            Console.WriteLine();

            //string cadenaG = "Enero
            //    Febrero
            //    Marzo";
            string cadenaG = @"Enero
                               Febrero
                               Marzo";

            string cadenaH = "Enero\nFebrero\nMarzo";

            Console.WriteLine(cadenaG);
            Console.WriteLine(cadenaH);

            Console.WriteLine();

            string cadenaI = "";
            string cadenaJ = string.Empty;

            Console.WriteLine("¿\"\" es igual que string.Empty? " + cadenaI.Equals(cadenaJ));
            Console.WriteLine("Longitud de string.Empty: " + cadenaJ.Length);

            Console.WriteLine();

            double numero = 18.25;
            //string cadenaK = (string)numero;
            string cadenaK = numero.ToString();

            Console.WriteLine($"numero: {numero} - cadena: {cadenaK}");

            Console.WriteLine();

            // using System.Text;
            StringBuilder cadenaL = new StringBuilder();
            Console.WriteLine("¿new StringBuilder() es igual que string.Empty? " + cadenaL.Equals(cadenaJ));

            Console.WriteLine();

            StringBuilder cadenaM = new StringBuilder(".Net");
            cadenaM.Append(" de Microsoft"); // equivalente en string a hacer ".Net" + " de Microsoft"

            StringBuilder cadenaN = new StringBuilder("Fecha: ");
            cadenaN.AppendFormat("{0:dd/MM/yyyy}", DateTime.Today);

            Console.WriteLine(cadenaM);
            Console.WriteLine(cadenaN);

            string num = "13,25";
            double numint = double.Parse(num);

            int result = 0;

            if (int.TryParse(num, out result))
            {

            }
            else
            {
                Console.WriteLine("Errorrr");
            }
        }
    }
}
