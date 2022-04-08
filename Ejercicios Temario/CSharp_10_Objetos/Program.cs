using System;

namespace CSharp_10_Objetos
{

    class Program
    {
        static void Main(string[] args)
        {
            Rotulador rotuladorSimple = new Rotulador();

            Console.WriteLine("rotuladorSimple .GetType(): " + rotuladorSimple.GetType());
            Console.WriteLine("rotuladorSimple     .Color: " + rotuladorSimple.Color);
            Console.WriteLine("rotuladorSimple    .Grosor: " + rotuladorSimple.Grosor);
            Console.WriteLine("rotuladorSimple.Permanente: " + rotuladorSimple.Permanente);
            Console.WriteLine("rotuladorSimple.NivelTinta: " + rotuladorSimple.NivelTinta);

            rotuladorSimple.Color = "negro";
            rotuladorSimple.Grosor = 10;

            Console.WriteLine("rotuladorSimple     .Color: " + rotuladorSimple.Color);
            Console.WriteLine("rotuladorSimple    .Grosor: " + rotuladorSimple.Grosor);

            Console.WriteLine();

            Rotulador rotuladorVerde = new Rotulador("verde", 2.7, true);

            Console.WriteLine("rotuladorVerde .GetType() : " + rotuladorVerde.GetType());
            Console.WriteLine("rotuladorVerde     .Color : " + rotuladorVerde.Color);
            Console.WriteLine("rotuladorVerde    .Grosor : " + rotuladorVerde.Grosor);
            Console.WriteLine("rotuladorVerde.Permanente : " + rotuladorVerde.Permanente);
            Console.WriteLine("rotuladorVerde.NivelTinta : " + rotuladorVerde.NivelTinta);

            int dibujoVerde = 12;

            rotuladorVerde.Pintar(dibujoVerde);

            Console.WriteLine("rotuladorVerde.TieneTinta : " + rotuladorVerde.TieneTinta());
            Console.WriteLine("rotuladorVerde.NivelTinta : " + rotuladorVerde.NivelTinta);


        }
    }
}
