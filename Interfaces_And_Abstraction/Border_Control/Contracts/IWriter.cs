using System;
namespace Border_Control.Contracts
{
    public interface IWriter
    {
        public void Write(string text);
        public void WriteLine(string text);
    }
}
