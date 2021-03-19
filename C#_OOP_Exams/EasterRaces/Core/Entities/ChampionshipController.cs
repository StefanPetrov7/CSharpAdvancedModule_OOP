using System;
using System.Collections.Generic;
using System.Linq;

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
            ICar car;

            if (type == typeof(MuscleCar).Name)
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (true)
            {
                car = new SportsCar(model, horsePower);
            }

            if (this.carRepo.GetAll().ToList().Contains(car))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            this.carRepo.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, car.Model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (!this.driverRepo.GetAll().ToList().Contains(driver))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            this.driverRepo.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (this.raceRepo.GetAll().ToList().Contains(race))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            this.raceRepo.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            foreach (IRace race in this.raceRepo.GetAll().ToList())
            {
                foreach (IDriver driver in this.driverRepo.GetAll().ToList())
                {
                    driver.Car.CalculateRacePoints(race.Laps);
                }
            }

            //List<IDriver> sertedDrivers = this.driverRepo.GetAll().ToList().OrderByDescending(d=>d.Car.CalculateRacePoints
        
        }
    }
}
