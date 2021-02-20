using System;

using Telephony.Core;
using Telephony.Contracts;
using Telephony.IO;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
