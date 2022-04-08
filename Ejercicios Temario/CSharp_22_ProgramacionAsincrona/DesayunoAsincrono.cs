using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_22_ProgramacionAsincrona.Ingredientes;

namespace CSharp_22_ProgramacionAsincrona
{
    public class DesayunoAsincrono
    {
        // Ejemplo desayuno: Cafe, triturar tomate, aceite, tostada y zumo de manera asincrono
        /*static async Task Main(string[] args)
        {
            
            // De forma asincrona
            // 1. Dar de alta las tareas
            Task<Cafe> cafeTask = HacerCafe();
            Task<Zumo> zumoTask = HacerZumo();
            //
            Task<Tostada> tostadaTask = HacerTostadaConTomate(2);

            // 2.
            //    a. Esperar a que finalicen las tareas llamandolas de una en una:
            //Zumo zumo = await zumoTask;
            //Tostada tostada = await tostadaTask;
            //Cafe cafe = await cafeTask;
            
            //    b. Usar la clase Task para llamarlas todas juntas
            await Task.WhenAll(zumoTask, cafeTask, tostadaTask);
            Console.WriteLine("Zumo listo");
            Console.WriteLine("Cafe listo");
            Console.WriteLine("Tostadas con tomate y aceite listas");


            Console.WriteLine("Desayuno terminado");
        }*/

        // Esperar a la finalizaciond de las Tareas de manera más eficaz
        static async Task Main(string[] args)
        {
            // Dar de alta tareas
            Task<Cafe> cafeTask = HacerCafe();            
            Task<Zumo> zumoTask = HacerZumo();
            Task<Tostada> tostadaTask = HacerTostadaConTomate(2);

            // Listado de tareas
            var allTask = new List<Task> { cafeTask, tostadaTask, zumoTask };
            // Recorrer mientras queden tareas
            while (allTask.Any())
            {
                // Objeto Task de tareas para saber si han acabado
                Task acabadas = await Task.WhenAny(allTask);
                if(acabadas == cafeTask)
                {
                    Console.WriteLine("Cafe listo");
                    // Tenemos que quitarlas de la lista de tareas
                    allTask.Remove(cafeTask);
                    // Asignar el resultado de la tarea
                    Cafe cafe = await cafeTask;
                }
                else if(acabadas == tostadaTask)
                {
                    Console.WriteLine("Tostadas con tomate y aceite listas");
                    allTask.Remove(tostadaTask);
                    Tostada cafe = await tostadaTask;
                }
                else if (acabadas == zumoTask)
                {
                    Console.WriteLine("Zumo listo");
                    allTask.Remove(zumoTask);
                    Zumo cafe = await zumoTask;
                }
                else
                {
                    allTask.Remove(acabadas);
                }
            }

            Console.WriteLine("Desayuno terminado");
        }


        async static Task<Tostada> HacerTostadaConTomate(int numero)
        {
            var tostadasPreparadas = await TostarPan(numero);
            AplicarAceite(tostadasPreparadas);
            AplicarTomate(tostadasPreparadas);
            return tostadasPreparadas;
        }

        public static async Task<Zumo> HacerZumo()
        {
            Console.WriteLine("    Zumo expremiendose....");
            await Task.Delay(4000);
            return new Zumo();
        }

        public static async Task<Tostada> TostarPan(int v)
        {
           
            Console.WriteLine("    Tostadora haciendo su trabajo....");
            await Task.Delay(3000);
            return new Tostada();
        }

        public static async Task<Cafe> HacerCafe()
        {
            Console.WriteLine("    Cafe haciendose....");
            await Task.Delay(5000);
            return new Cafe();
        }

        public static void AplicarTomate(Tostada toast)
        {
            Console.WriteLine("    Echando tomate en la tostada....");      
        }

        public static void AplicarAceite(Tostada toast)
        {
            Console.WriteLine("    Echando aceite en la tostada....");
            
        }
    }
}
