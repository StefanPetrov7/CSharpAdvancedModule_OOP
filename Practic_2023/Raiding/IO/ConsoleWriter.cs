﻿using Raiding.Contracts;
namespace Raiding.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);
    
    }
}

