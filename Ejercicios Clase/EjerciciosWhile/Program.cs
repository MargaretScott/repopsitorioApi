Console.WriteLine("Introduzca el maximo de la iteracion ");

int max = -1;
int index = 1;
Int32.TryParse(Console.ReadLine(), out max);

if (max < 0)
{
    Console.WriteLine("Debe introducir un numero válido");
}
else
{
    while (index <= max)
    {
        if (index == 1)
        {
            Console.WriteLine("La iteracion desde 1 es: ");
        }
        Console.WriteLine(index);
        index++;
    }

    index = 0;

    do
    {
        if (index == 0)
        {
            Console.WriteLine("La iteracion desde 0 es: ");
        }
        Console.WriteLine(index);
        index++;
    } while (index <= max);
}
