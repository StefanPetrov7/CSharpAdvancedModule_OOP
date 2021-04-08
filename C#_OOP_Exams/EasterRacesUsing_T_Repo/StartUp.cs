using System;
using EasterRaces.Core.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            //string filePath = Path.Combine("..", "..", "..", "result.txt");   // When using FileWriter as writer
            //File.Create(filePath).Close();

            IChampionshipController controller = new ChampionshipController();

            IReader reader = new ConsoleReader();

            //IWriter writer = new FileWriter();   // wWhen using FileWriter as writer

            IWriter sbWriter = new SBWriter();   // When using StringBuilder as writer

            IEngine enigne = new Engine(controller, reader, sbWriter);
            enigne.Run();


            Console.Clear();
            Console.WriteLine(sbWriter);  // When using StringBuilder as writer
        }
    }
}
