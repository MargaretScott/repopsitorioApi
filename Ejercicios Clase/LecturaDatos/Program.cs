Console.Write("¿Dime el radio de la esfera a calcular? ");
Console.WriteLine();
float pi = 3.1415926535f;
int radio = 0;
Int32.TryParse(Console.ReadLine(), out radio);
//Validar con un if radio es 0
if (radio == 0 || radio < 0)
{
    Console.WriteLine("Debe introducir un numero valido y mayor que 0");
}
else
{
    var superficie = Math.Round(4 * pi * (radio * radio), 2);
    var volumen = Math.Round(4 / 3 * pi * (radio * radio * radio), 2);

    Console.WriteLine("La superficie es, " + superficie, 2);
    Console.WriteLine("El volumen es, " + volumen, 2);
}