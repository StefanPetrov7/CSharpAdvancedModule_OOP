using System;
namespace Military_Elite.Exeptions
{
    public class InvalidCorpsException : Exception
    {
        private const string INVALIDE_CORPS_MSG = "Ivalide corps";

        public InvalidCorpsException() : base(INVALIDE_CORPS_MSG)
        {
        }

        public InvalidCorpsException(string message) : base(message)
        {

        }
    }
}
