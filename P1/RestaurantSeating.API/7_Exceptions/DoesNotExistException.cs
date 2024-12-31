using System;

namespace RestaurantSeating.API.Exceptions
{
    public class DoesNotExistException : Exception
    {
        public DoesNotExistException() : base("The requested item does not exist.")
        {
        }

        public DoesNotExistException(string message) : base(message)
        {
        }

        public DoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}