using System;
namespace Practice.Exceptions
{
    public class InvalideCorps : Exception
    {
        private const string INVALID_CORPS = "InvalideCorps";

        public InvalideCorps() : base(INVALID_CORPS)
        {
        }

        public InvalideCorps(string message) : base(message)
        {

        }
    }
}
