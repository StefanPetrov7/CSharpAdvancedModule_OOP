using System;
using ExLogger.Models.Enumerations;

namespace ExLogger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
