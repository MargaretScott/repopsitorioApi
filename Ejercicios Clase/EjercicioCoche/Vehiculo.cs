namespace EjercicioCoche
{
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Combustible { get; set; }
        public int CapacidadDeposito { get; set; }
        public int Consumo { get; set; }


        public Vehiculo()
        {
            CapacidadDeposito = 50;
            Consumo = 7;
        }

        public Vehiculo(string marca, string color, string combustible)
        {
            Marca = marca;
            Color = color;
            Combustible = combustible;
            CapacidadDeposito = 50;
            Consumo = 7;
        }

        public int CalculoNivelCombustible(int kms)
        {
            int nivelCombustible = CapacidadDeposito - (Consumo * (kms/100));

            return nivelCombustible;
        }
    }
}
