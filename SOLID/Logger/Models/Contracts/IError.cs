using System;
using ExLogger.Models.Enumerations;

namespace ExLogger.Models.Contracts
{
    public interface IError
    {

        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
