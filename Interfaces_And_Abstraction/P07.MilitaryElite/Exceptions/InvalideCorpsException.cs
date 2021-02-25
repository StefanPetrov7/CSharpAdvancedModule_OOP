using System;
namespace P07.MilitaryElite.Exceptions
{
    public class InvalideCorpsException : Exception
    {
        private const string DEFAULT_EXCEPTION_MSG = "Invalide corps";

        public InvalideCorpsException() : base(DEFAULT_EXCEPTION_MSG)
        {
        }

        public InvalideCorpsException(string message) : base(message)
        {

        }
    }
}
