namespace EjemploInterfaz
{
    public interface IPersona
    {
        string Nombre { get; set; }

        string Apellidos { get; set; }

        void SetEdad(int edad);

        int CalcularAñoNacimiento();

    }
}
