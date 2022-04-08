namespace EjercicioInterfazCoche
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Vehiculo vehiculo = new Vehiculo(0);

            Console.WriteLine("Introduzca una cantidad de gasolina:");

            int cantidadGasolina = int.Parse(Console.ReadLine());

            bool repostaje = vehiculo.Respostar(cantidadGasolina);

            if(repostaje)
            {
                vehiculo.Conducir();
            }

        }
    }

}
