using System;
using WarCroft.Core;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft
{
    public class StartUp
	{
		public static void Main(string[] args)
		{
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();
            //var engine = new Engine(reader, writer);
            //engine.Run();


            IReader reader = new ConsoleReader();
            var sbWriter = new StringBuilderWriter();
            var engine = new Engine(reader, sbWriter);
            engine.Run();
            Console.WriteLine(sbWriter.sb.ToString().Trim());
        }
	}
}