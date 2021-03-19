using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            ICar car = new MuscleCar("Mustang", 399);
            System.Console.WriteLine(car);

            IChampionshipController controller = null; //new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
