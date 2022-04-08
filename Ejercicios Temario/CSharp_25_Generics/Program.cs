using System;

namespace CSharp_25_Generics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instanciar nuestra clase generica como tipo int
            MiClaseGenerica<int> intClaseGenerica = new MiClaseGenerica<int>(200);
            intClaseGenerica.PropiedadGenerica = 9;
            int val = intClaseGenerica.MetodoGenerico(8);
            
            // Instanciar nuestra clase generica como tipo string
            MiClaseGenerica<string> stringClaseGenerica = new MiClaseGenerica<string>("Hello Generic World");
            stringClaseGenerica.PropiedadGenerica = "This is a generic property example.";
            string result = stringClaseGenerica.MetodoGenerico("Parametro");
        }
    }
    
    class MiClaseGenerica<T>
    {
        private readonly T _respuestaGenerica;

        public MiClaseGenerica(T value)
        {
            _respuestaGenerica = value;
        }

        public T MetodoGenerico(T param)
        {
            Console.WriteLine("Tipo: {0}, Parametro del método: {1}, Respuesta: {2}", typeof(T).ToString(), param, _respuestaGenerica);

            return _respuestaGenerica;
        }

        public T PropiedadGenerica { get; set; }
    }
}
