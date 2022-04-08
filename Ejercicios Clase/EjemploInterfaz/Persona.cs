namespace EjemploInterfaz
{
    public class Persona : IPersona
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        private int Edad { get; set; }

        public int CalcularAñoNacimiento()
        {
           return 2022 - Edad;
        }

        public void SetEdad(int edad)
        {
            Edad = edad;
        }

        private void Escribir()
        {
            Console.WriteLine("");
        }
    }
}