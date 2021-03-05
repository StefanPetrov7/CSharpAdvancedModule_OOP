using System;
namespace ExLogger.Models.IOManagment.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
