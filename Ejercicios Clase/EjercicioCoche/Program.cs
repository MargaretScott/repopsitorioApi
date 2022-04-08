namespace EjercicioCoche
{
    public class CalculadoraBasicaSwitch
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Escriba la marca de su coche 1: ");
            string marca = Console.ReadLine();
            Console.WriteLine("Escriba el color de su coche 1: ");
            string color = Console.ReadLine();
            Console.WriteLine("Escriba el combustible de su coche 1: ");
            string combustible = Console.ReadLine();
            Console.WriteLine("Escriba los km recorridos en su coche 1: ");
            int kms = int.Parse(Console.ReadLine());

            //Llamada al constructor con parametros para instanciar la clase
            Vehiculo vehiculoNuevo = new Vehiculo(marca, color, combustible);

            //Aqui se hace una llamada al metodo CalculoNivelCombustible de la clase coche
            int nivelCombustible = vehiculoNuevo.CalculoNivelCombustible(kms);

            Console.WriteLine("Le quedan: " + nivelCombustible + "litros al coche 1");

            Console.WriteLine("Escriba la marca de su coche 2: ");
            string marca2 = Console.ReadLine();
            Console.WriteLine("Escriba el color de su coche 2: ");
            string color2 = Console.ReadLine();
            Console.WriteLine("Escriba el combustible de su coche 2: ");
            string combustible2 = Console.ReadLine();
            Console.WriteLine("Escriba los km recorridos en su coche 2: ");
            int kms2 = int.Parse(Console.ReadLine());

            //Llamada al constructor con parametros para instanciar la clase
            Vehiculo vehiculoNuevo2 = new Vehiculo(marca2, color2, combustible2);

            //Aqui se hace una llamada al metodo CalculoNivelCombustible de la clase coche para el coche 2
            int nivelCombustible2 = vehiculoNuevo2.CalculoNivelCombustible(kms2);

            Console.WriteLine("Le quedan: " + nivelCombustible2 + "litros al coche 2");

            Moto moto = new Moto();
            moto.Saludar();
        }

    }
}
