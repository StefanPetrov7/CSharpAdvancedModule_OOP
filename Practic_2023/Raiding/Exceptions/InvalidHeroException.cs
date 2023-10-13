using System;
namespace Raiding.Exceptions
{
    public class InvalidHeroException : Exception
    {
        private const string MESSAGE = "Invalid hero!";

        public InvalidHeroException() : base(MESSAGE)
        { }

        public InvalidHeroException(string message) : base(message)
        { }
    }
}

