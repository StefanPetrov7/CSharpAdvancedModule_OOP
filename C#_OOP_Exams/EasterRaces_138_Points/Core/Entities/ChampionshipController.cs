using System;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IDriver> drivers;
        private readonly IRepository<IRace> races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = this.cars.GetByName(carModel);
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }


            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            IDriver driver = this.drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = this.cars.GetByName(model);

            if (car == null)
            {
                if (type == "Sports")
                {
                    car = new SportsCar(model, horsePower);
                }
                else if (type == "Muscle")
                {
                    car = new MuscleCar(model, horsePower);
                }

                this.cars.Add(car);
                return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
            }

            throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                driver = new Driver(driverName);
                this.drivers.Add(driver);
                return string.Format(OutputMessages.DriverCreated, driverName);
            }

            throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));

        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.races.GetByName(name);

            if (race == null)
            {
                race = new Race(name, laps);
                this.races.Add(race);
                return string.Format(OutputMessages.RaceCreated, name);
            }

            throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IDriver[] winners = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();
            IDriver winnerDriver = winners[0];
            winnerDriver.WinRace();
            StringBuilder results = new StringBuilder();
            results.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, race.Name));
            results.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, race.Name));
            results.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, race.Name));
            this.races.Remove(race);
            return results.ToString().TrimEnd();
        }
    }
}