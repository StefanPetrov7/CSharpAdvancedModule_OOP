using System;
using System.Collections.Generic;

using Collection_Hierarchy.Contracts;
using Collection_Hierarchy.Core;
using Collection_Hierarchy.IO;
using Collection_Hierarchy.Models;

namespace Collection_Hierarchy
{
    class StartUp
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
