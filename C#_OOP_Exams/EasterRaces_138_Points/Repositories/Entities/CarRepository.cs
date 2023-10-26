using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> cars;

        public CarRepository()
        {
            this.cars = new Dictionary<string, ICar>();
        }

        public void Add(ICar car) => this.cars[car.Model] = car;

        public IReadOnlyCollection<ICar> GetAll() => this.cars.Values.ToList();
      
        public ICar GetByName(string model)
        {
            if (this.cars.ContainsKey(model))
            {
                return this.cars[model] as Car;
            }

            return null;
        }

        public bool Remove(ICar car) => this.cars.Remove(car.Model);
    }
}