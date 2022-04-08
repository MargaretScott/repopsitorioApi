namespace EjercicioClasesNet
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public Persona()
        {
        }

        public int CalcularAnoNacimiento(int edad)
        {
            int anoNacimiento = 2022 - edad;

            return anoNacimiento;
        }
    }
}
