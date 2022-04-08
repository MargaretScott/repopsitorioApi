using System;
public class CalculadoraBasicaSwitch
{
    public static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        char operacion = Convert.ToChar(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());

        int resultado = Calcular(a,b, operacion);

        EscribirFrase(string.Format("{0}{1}{2}= {3}", a, operacion, b, resultado));

    }

    public static int Calcular(int a, int b, char operacion)
    {
        int result = 0;

        switch (operacion)
        {
            case '+':
                result = a + b;
                break;
            case '-':
                result = a - b;
                break;
            case 'x':
            case '*':
                result = a * b;
                break;
            case '/':
                result = a / b;
                break;
            default:
                break;
        }

        return result;
    }

    public static void EscribirFrase(string mensaje)
    {
        Console.WriteLine(mensaje);
    }
}