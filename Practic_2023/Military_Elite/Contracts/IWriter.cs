using System;
namespace Military_Elite.Contracts
{
    public interface IWriter
    {
        public void Write(string message);

        public void WriteLine(string message);
    }
}

