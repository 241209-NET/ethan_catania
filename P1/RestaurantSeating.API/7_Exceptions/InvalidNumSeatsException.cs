using System;

namespace RestaurantSeating.API.Exceptions
{
    public class InvalidNumSeatsException : Exception
    {
        public InvalidNumSeatsException() : base("The number of seats provided is invalid.")
        {
        }

        public InvalidNumSeatsException(string message) : base(message)
        {
        }

        public InvalidNumSeatsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}