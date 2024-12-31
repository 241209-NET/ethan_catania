using System;

namespace RestaurantSeating.API.Exceptions
{
    public class InvalidNumTablesException : Exception
    {
        public InvalidNumTablesException()
        {
        }

        public InvalidNumTablesException(string message)
            : base(message)
        {
        }

        public InvalidNumTablesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}