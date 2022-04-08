using System;

namespace CSharp_24_Eventos
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Evento e = new Evento();
            
            // Crear el evento y asignar al metodo que queremos
            e.EventHandler += OnEvento;

            // Llamamos al evento con los parametros de entrada
            e.OnEvento(new BaseEventArgs { Propiedad1=1, Propiedad2=" Hello"});
        }

        public static void OnEvento(object sender, BaseEventArgs e)
        {
            Console.WriteLine(string.Concat(e.Propiedad1.ToString(), e.Propiedad2));
        }

        public class Evento
        {
            // Evento tipado por medio de la clase TEventArgs
            public event EventHandler<BaseEventArgs> EventHandler;

            public void OnEvento(BaseEventArgs eventArgs)
            {
                EventHandler<BaseEventArgs> handler = EventHandler;
                handler?.Invoke(this, eventArgs);
            }
        }

        public class BaseEventArgs : EventArgs
        {
            public int Propiedad1 { get; set; }
            public string Propiedad2 { get; set; }
        }
    }
}
