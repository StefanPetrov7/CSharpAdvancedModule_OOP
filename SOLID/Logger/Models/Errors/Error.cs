using System;
using ExLogger.Models.Contracts;
using ExLogger.Models.Enumerations;

namespace ExLogger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime date, string message, Level level)
        {
            this.DateTime = date;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
