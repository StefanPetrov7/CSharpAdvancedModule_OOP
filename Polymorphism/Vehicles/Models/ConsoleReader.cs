using System;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class ConsoleReader: IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        } 
    }
}
