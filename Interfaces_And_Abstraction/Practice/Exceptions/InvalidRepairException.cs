using System;
namespace Practice.Exceptions
{
    public class InvalidRepairException : Exception
    {
        private const string INVALID_REPAIR = "InvalidRepairException";

        public InvalidRepairException() : base(INVALID_REPAIR)
        {
        }

        public InvalidRepairException(string message) : base(message)
        {

        }
    }
}
