using System;

namespace RestaurantSeating.API.Exceptions
{
    public class InvalidAccessException : Exception
    {
        public InvalidAccessException() : base("Invalid access. Must be One of the following: BOOTH, WHEELCHAIR, TABLE")
        {
        }

        public InvalidAccessException(string message) : base(message)
        {
        }

        public InvalidAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}