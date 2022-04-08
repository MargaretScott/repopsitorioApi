 using System;
public class UsandoDoWhile
{
    public static void Main(string[] args)
    {
        int x;
       
        do
        {
           x = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine(x * 10);
        }
        while (x != 0) ;
    }
}

