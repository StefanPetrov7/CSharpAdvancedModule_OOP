using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IDictionary<string, IRace> races;

        public RaceRepository()
        {
            this.races = new Dictionary<string, IRace>();
        }

        public void Add(IRace race) => this.races[race.Name] = race;

        public IReadOnlyCollection<IRace> GetAll() => this.races.Values.ToList();

        public IRace GetByName(string name)
        {
            if (this.races.ContainsKey(name))
            {
                return this.races[name] as Race;
            }

            return null;
        }

        public bool Remove(IRace race) => this.races.Remove(race.Name);
    }
}