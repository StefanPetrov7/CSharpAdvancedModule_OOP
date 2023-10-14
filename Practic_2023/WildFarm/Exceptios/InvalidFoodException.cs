using System;
namespace WildFarm.Exceptios
{
    public class InvalidFoodException : Exception
    {
        public InvalidFoodException() : base()
        { }

        public InvalidFoodException(string message) : base(message)
        { }
    }
}

