using System;

namespace CSharp_18_Excepciones
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                // Bloque de código a inspeccionar

                // 1. Capturar excepción
                //object cadena = "Hola";
                //int convertir = (int)cadena;

                // 2. Lanzar excepciones
                 LanzarExcepcion();

                // 3. Lanzar nuestra propia excepcion
                //LanzarMiPropiaExcepcion();
            }
            // Capturar las posibles excepciones
            catch (MyCustomException e)
            {
                Console.WriteLine("Error! MyCustomException Message = {0}", e.Message);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Error! InvalidCastException Message = {0}", e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message Exception = {0}", ex.Message);
            }
            // Se ejecuta siempre al final del bloque try catch
            finally
            {
                Console.WriteLine("Ejecutando bloque finally...");
            }
        }

        public static int LanzarExcepcion()
        {
            try
            {                
                object cadena = "Hola";
                int convertir = (int)cadena;
            }            
            catch (Exception ex)
            {
                //Lanzara la excepción
                throw ex;
            }
            finally
            {
                Console.WriteLine("Ejecutando bloque finally al lanzar la excepción...");
            }

            return -1;
        }

        public static void LanzarMiPropiaExcepcion()
        {
            throw new MyCustomException("Mensaje de error personalizado", new SystemException());
        }
    }
}
