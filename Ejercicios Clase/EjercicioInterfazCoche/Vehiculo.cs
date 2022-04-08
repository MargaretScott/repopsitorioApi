namespace EjercicioInterfazCoche
{
    public class Vehiculo : IVehiculo
    {
        public int CantidadGasolina { get; set; }

        public Vehiculo(int cantidadInicial)
        {
            CantidadGasolina = cantidadInicial;
        }

        public void Conducir()
        {
            if (CantidadGasolina > 0)
                Console.WriteLine("Conduciendo");
            else
                Console.WriteLine("No hay gasolina");
        }

        public bool Respostar(int cantidadGasolina)
        {
            CantidadGasolina += cantidadGasolina;

            return true;
        }
    }
}
