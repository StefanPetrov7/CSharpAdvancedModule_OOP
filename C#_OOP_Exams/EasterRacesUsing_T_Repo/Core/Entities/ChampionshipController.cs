using System;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<ICar> carRepo;
        private IRepository<IDriver> driverRepo;
        private IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            this.carRepo = new CarRepository();
            this.driverRepo = new DriverRepository();
            this.raceRepo = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!driverRepo.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (!this.carRepo.GetAll().Any(c => c.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            this.driverRepo.GetAll().FirstOrDefault(d => d.Name == driverName)
                .AddCar(this.carRepo.GetAll().FirstOrDefault(c => c.Model == carModel));

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.raceRepo.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (!driverRepo.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            this.raceRepo.GetAll().FirstOrDefault(r => r.Name == raceName)
              .AddDriver(this.driverRepo.GetAll().FirstOrDefault(d => d.Name == driverName));

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
            if (driverRepo.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            this.driverRepo.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepo.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepo.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }


        public string StartRace(string raceName)
        {
            if (!this.raceRepo.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = this.raceRepo.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            this.raceRepo.Remove(race);

            var winners = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {winners[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {winners[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {winners[2].Name} is third in {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
