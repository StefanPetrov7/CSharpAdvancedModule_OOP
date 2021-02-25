using System;
namespace P07.MilitaryElite.Exceptions
{
    public class InvalidStatusException : Exception
    {
        private const string INVALID_STATUS = "Invalid Status";

        public InvalidStatusException() : base(INVALID_STATUS)
        {
        }

        public InvalidStatusException(string message) : base(message)
        {

        }
    }
}
