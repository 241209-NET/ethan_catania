using System;

namespace RestaurantSeating.API.Exceptions
{
    public class InvalidStatusException : Exception
    {
        public InvalidStatusException(string status)
            : base($"Invalid status: {status}. Status should be OPEN, OCCUPIED, or RESERVED.")
        {
        }
    }
}