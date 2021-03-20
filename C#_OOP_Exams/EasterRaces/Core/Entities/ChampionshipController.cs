using System;
using System.Collections.Generic;
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
        private IRepository<IDriver> driverRepo = new DriverRepository();
        private IRepository<IRace> raceRepo = new RaceRepository();
        private IRepository<ICar> carRepo = new CarRepository();

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepo.GetByName(driverName);
            ICar car = this.carRepo.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            this.carRepo.Remove(car);  // Not necesssry
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = this.driverRepo.GetByName(driverName);
            IRace race = this.raceRepo.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepo.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            if (type + "Car" == typeof(MuscleCar).Name)
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type + "Car" == typeof(SportsCar).Name)
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepo.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, car.Model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = this.driverRepo.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            this.driverRepo.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {

            if (this.raceRepo.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepo.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();
            IRace race = this.raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            this.raceRepo.Remove(race);
            List<IDriver> drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            IDriver first = drivers.FirstOrDefault();
            IDriver second = drivers.Skip(1).FirstOrDefault();
            IDriver third = drivers.Skip(2).FirstOrDefault();
            first.WinRace();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, first.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, second.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, third.Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}
