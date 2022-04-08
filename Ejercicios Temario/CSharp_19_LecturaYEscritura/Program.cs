using System;
using System.IO;
using System.Text;

namespace CSharp_19_LecturaYEscritura
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region Escribir y Leer con MemoryStream

            //Console.WriteLine("Introduce la información a escribir:");
            //string userInfo = Console.ReadLine();

            //MemoryStream memStream = new MemoryStream(50);
            //byte[] buffer;

            //// Escribir el MemoryStream los bytes del nombre introducido
            //memStream.Write(ASCIIEncoding.ASCII.GetBytes(userInfo), 0, userInfo.Length);
            //// Propiedades de MemoryStream
            //Console.WriteLine(
            //    "Capacidad = {0}, Longitud = {1}, Posicion = {2}\n",
            //    memStream.Capacity.ToString(),
            //    memStream.Length.ToString(),
            //    memStream.Position.ToString());

            //// Nos posicionamos en el inicio del stream
            //memStream.Seek(0, SeekOrigin.Begin);

            //// Leemos los primeros 5 carácteres
            //buffer = new byte[50];
            //memStream.Read(buffer, 0, 5);

            //// Mostrar por consola el contenido que hemos escrito
            //Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer));

            //// Cerrar MemoryStream
            //memStream.Close();

            #endregion

            #region Escribir y Leer desde Fichero
                       
            // Crear la ruta y nombre del fichero
            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreFichero = "texto.txt";
            string rutaCompleta = Path.Combine(documentos, nombreFichero);

            // Crear FileStream para escribir en modo Create
            FileStream fileStream = new FileStream(rutaCompleta, FileMode.Create);
            Console.WriteLine("Fichero alojado en: {0}",rutaCompleta);

            string cadena = "Contenido a escribir en fichero. ";

            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0, cadena.Length);
            fileStream.Close();

            // Con File añadimos más contenido al fichero actual con Append
            string[] lines = { "Nueva linea 1 ", "Nueva linea 2 " };
            File.AppendAllLines(rutaCompleta, lines);

            // Leer el contenido del archivo con FileStream
            byte[] infoArchivo = new byte[100];

            FileStream fileStream1 = new FileStream(rutaCompleta, FileMode.Open);
            fileStream1.Read(infoArchivo, 0, (int)fileStream1.Length);

            Console.WriteLine(ASCIIEncoding.ASCII.GetString(infoArchivo));
                       
            fileStream1.Close();

            // Leer el contenido del archivo usando StreamReader 
            StreamReader streamReader = new StreamReader(rutaCompleta);
            
            string line = streamReader.ReadToEnd();
            Console.WriteLine(line);

            streamReader.Close();

            #endregion 

        }
    }
}
