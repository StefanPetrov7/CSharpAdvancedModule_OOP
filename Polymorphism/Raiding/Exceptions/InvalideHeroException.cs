using System;
namespace Raiding.Exceptions
{
    public class InvalideHeroException : Exception
    {
        private const string INVALIDE_HERO_MSG = "Invalid hero!";

        public InvalideHeroException() : base(INVALIDE_HERO_MSG)
        {
        }

        public InvalideHeroException(string message) : base(message)
        {
        }
    }
}
