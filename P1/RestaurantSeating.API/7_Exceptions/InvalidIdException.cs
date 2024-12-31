using System;

namespace RestaurantSeating.API.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("The provided ID is invalid.")
        {
        }

        public InvalidIdException(string message) : base(message)
        {
        }

        public InvalidIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}