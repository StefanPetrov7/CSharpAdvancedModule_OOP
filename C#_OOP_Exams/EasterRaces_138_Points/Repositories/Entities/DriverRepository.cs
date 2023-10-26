using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new Dictionary<string, IDriver>();
        }

        public void Add(IDriver driver) => this.drivers[driver.Name] = driver;

        public IReadOnlyCollection<IDriver> GetAll() => this.drivers.Values.ToList();

        public IDriver GetByName(string name)
        {
            if (this.drivers.ContainsKey(name))
            {
                return this.drivers[name] as Driver;
            }

            return null;
            
        }

        public bool Remove(IDriver driver) => this.drivers.Remove(driver.Name);
    }
}