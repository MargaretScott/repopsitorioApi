public class CalculadoraBasicaIf
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hola Como te llamas? ");

        string? nombre = Console.ReadLine();

        Saludar(nombre);

        Despedir();
    }

    private static void Saludar(string? nombre)
    {
        Console.WriteLine("Hola " + nombre);
    }

    private static void Despedir()
    {
        Console.WriteLine("Adios");
    }
}