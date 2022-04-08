int x;

do
{
    Console.WriteLine("Introduzca un numero: ");
    int.TryParse(Console.ReadLine(), out x);
    if(x == 0)
    {
        break;
    }
    Console.WriteLine("El resultado es: " + x * 10);

} while (x != 0);
