using System;
using System.Collections;

namespace CSharp_16_Listas_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList

            // Crear un ArrayList
            ArrayList arrayList = new ArrayList();

            // Añadir elementos
            arrayList.Add("Kiwi");
            arrayList.Add("Pera");
            arrayList.Add(2);
            arrayList.Add("Arandano");
            arrayList.Add(9);

            //Mostrar todos los elementos
            foreach (var item in arrayList)
                Console.WriteLine(item);

            // Mostrar la cantidad de elementos
            Console.WriteLine(arrayList.Count);

            // Mostrar una posición cualquiera
            Console.WriteLine($"La posicion 2 se encuentra: {arrayList[1]}");

            // Buscar un elemento
            var elementoEncontrado = arrayList.IndexOf("Pera");
            Console.WriteLine($"Index de Pera es: {elementoEncontrado}");

            // Insertar en la segunda posicion 
            arrayList.Insert(1, "Mandarina");

            Console.WriteLine("Insertado nuevo elemento: ");
            foreach (var item in arrayList)
                Console.WriteLine(item);

            // Borrar por su index o por su tipo
            arrayList.RemoveAt(1);
            arrayList.Remove("Kiwi");

            // Mostrar la lista final
            Console.WriteLine("Lista final: ");
            foreach (var item in arrayList)
                Console.WriteLine(item);

            #endregion

            #region Pila o Stack

            //LIFO (Last In First Out) --> el primero en entrar es el ultimo en salir
            Stack stack = new Stack();

            //Añadir elementos a una pila
            stack.Push(1);
            stack.Push(8);
            stack.Push(2);
            stack.Push(7);

            // Eliminar un elemento de la pila
            var numero = stack.Pop();
            Console.WriteLine($"El primero en salir es: {numero}");

            // Mostrar la pila actual
            foreach (var item in stack)
                Console.WriteLine(item);

            // Buscar un elemento
            if (stack.Contains(2))
                Console.WriteLine("Si contiene un 2");

            // Limpiar la pila
            stack.Clear();

            // Contar los número de elementos de la pila
            int contador = stack.Count;
            Console.WriteLine($"Cantidad de elementos en la pila: {contador}");

            #endregion

            #region Cola a Queue

            //FIFO (First In First Out) --> el primero en entrar es el primero en salir
            Queue queue = new Queue();

            // Añadir elementos a la cola
            queue.Enqueue(4);
            queue.Enqueue(9);
            queue.Enqueue(1);
            queue.Enqueue(20);

            // Extraer elemento de la cola
            var valorQueue = queue.Dequeue();
            Console.WriteLine($"El primero en salir es: {valorQueue}");

            valorQueue = queue.Dequeue();
            Console.WriteLine($"El primero en salir es: {valorQueue}");

            // Mostrar los elementos de la cola
            foreach (var item in queue)
                Console.WriteLine(item);

            // Observar el valor siguiente
            Console.WriteLine($"El siguiente valor es: {queue.Peek()}");

            // Buscar un elemento
            if (queue.Contains(1))
                Console.WriteLine("Si contiene un 1");

            // Cantidad de elementos que quedan en la cola
            Console.WriteLine(queue.Count);

            // Borrar la cola
            queue.Clear();

            #endregion

            #region Hastable

            Hashtable hashtable = new Hashtable();

            // Añadir valores
            hashtable.Add(2.1, "Naranka");
            hashtable.Add(3.2, "Pomelo");
            hashtable.Add(1.4, "Aguacate");

            // Mostrar los elementos usando un dicionario
            foreach (DictionaryEntry item in hashtable)
                Console.WriteLine(item.Key + " - " + item.Value);

            // Mostrar un elemento
            Console.WriteLine(hashtable["Pomelo"]);

            // Cantidad de elementos 
            Console.WriteLine(hashtable.Count);

            // Buscar un elemento por el valor
            var elementoValor = hashtable.ContainsValue("Aguacate");
            Console.WriteLine(elementoValor);

            // Eliminar por la key
            hashtable.Remove(1.4);

            // Buscar un elemento por el key
            var elementoKey = hashtable.ContainsKey(1.4);
            Console.WriteLine(elementoKey);

            // Borrar hashtable
            hashtable.Clear();

            #endregion
        }
    }
}
