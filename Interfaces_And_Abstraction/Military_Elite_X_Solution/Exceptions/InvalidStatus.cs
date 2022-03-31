using System;
namespace Military_Elite.Exceptions
{
    public class InvalidStatus : Exception
    {
        private const string INVALID_STATUS = "Invalid Mission Status";

        public InvalidStatus() : base(INVALID_STATUS)
        { }

        public InvalidStatus(string message) : base(message)
        { }
    }
}
