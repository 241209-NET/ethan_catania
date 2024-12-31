using System;

namespace RestaurantSeating.API.Exceptions
{
    public class InvalidServerIdException : Exception
    {
        public InvalidServerIdException() : base("The server ID provided is invalid.")
        {
        }

        public InvalidServerIdException(string message) : base(message)
        {
        }

        public InvalidServerIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}