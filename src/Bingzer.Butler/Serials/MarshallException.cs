using System;

namespace Bingzer.Butler.Serials
{
    public class MarshallException : Exception
    {
        public MarshallException()
        {
        }

        public MarshallException(Exception innerException) : base("InnerException occured", innerException)
        {
            
        }

        public MarshallException(string message) : base(message)
        {
        }

        public MarshallException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
