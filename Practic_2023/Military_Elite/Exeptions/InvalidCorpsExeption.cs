using System;
namespace Military_Elite.Exeptions
{
    public class InvalidCorpsExeption : Exception
    {

        private const string INVALID_CORPS_MESSAGE = "Invalide corps";

        public InvalidCorpsExeption() : base(INVALID_CORPS_MESSAGE)
        { }

        public InvalidCorpsExeption(string message) : base(message)
        { }
    }
}

