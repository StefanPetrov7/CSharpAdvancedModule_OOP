using System;
namespace Military_Elite.Exceptions
{
    public class InvalidCorps : Exception
    {
        private const string INVALID_CORPS = "Invalid Corps";

        public InvalidCorps() : base(INVALID_CORPS)
        { }

        public InvalidCorps(string message) : base(message)
        { }
    }
}
