namespace CSharp_12_Abstractas
{
    class Program
    {
        static void Main(string[] args)
        {
            // No se pueden instanciar objetos de clases abstractas.
            // Animal animalAbstracto = new Animal();

            // Las clases derivadas de una abstracta sí se pueden instanciar.
            Gato gato = new Gato();
            Lobo lobo = new Lobo();

            // Todos los objetos Gato, Lobo o Vaca son Animal.
            Animal vaca = new Vaca();

            // No se puede acceder a una propiedad privada desde fuera de la clase.
            //gato._ruido;

            // No se puede acceder a un método protegido desde fuera de la clase.
            //lobo.GetRuido();

            string ruidoGato = "Maullido";
            string ruidoLobo = "Aullido";
            string ruidoVaca = "Mugido";

            // Los métodos públicos sí son accesibles desde fuera de la clase.
            gato.SetRuido(ruidoGato);
            lobo.SetRuido(ruidoLobo);
            vaca.SetRuido(ruidoVaca);

            Animal[] animales = { gato, lobo, vaca };

            foreach (var animal in animales)
            {
                // Cada clase derivada ejecuta su propia implementación del método abstracto.
                if (animal.EstaVivo) animal.HacerSonido();
            }
        }
    }
}
