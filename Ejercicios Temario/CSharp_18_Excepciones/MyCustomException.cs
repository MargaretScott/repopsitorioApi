using System;
namespace CSharp_18_Excepciones
{
    public class MyCustomException : Exception
    {
        public MyCustomException()
        {
        }

        public MyCustomException(string message)
            : base(message)
        {
        }

        public MyCustomException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
