using System;

namespace CSharp_23_Delegados
{
    // Declaración del Delegado
    public delegate void Del(string message);

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instanciar el Delegado
            Del handler = DelegateMethod;

            // 1. Llamar al Delegado
            //handler("Hello Delegate");


            // 2. Llamar al Delegado desde un Callback
            //MethodWithCallback("Hello, ","how are you?", handler);


            // 3. Instanciar varios Delegado para encapsular metodoS instancia
            MethodClass obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;           

            // Al ser todos de la misma firma son válidos
            Del allMethodsDelegate = d1 + d2 + d3;
            //Del d4 = MethodWithCallback; -> Esto falla al no tener la misma firma

            // Llamar al Delegado que tiene todos que llamará todos sus métodos 
            allMethodsDelegate("Hello all delegates!");

            //Elimar un delegado
            allMethodsDelegate -= d2;

            //allMethodsDelegate("Hello all delegates!");

        }

        // Metodo asignado al Delegado
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        // Pasar un Delegado por parámetro
        public static void MethodWithCallback(string cadena1, string cadena2, Del callback)
        {
            callback(string.Concat(cadena1, cadena2));
        }                

    }
    
    public class MethodClass
    {

        public void Method1(string message)
        {
            Console.WriteLine(message);
        }

        public void Method2(string message)
        {
            Console.WriteLine(message);
        }

    }
}
