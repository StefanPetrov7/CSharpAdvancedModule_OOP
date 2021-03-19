using System.Collections.Generic;
using System.Linq;

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        void IRepository<IRace>.Add(IRace model)
        {
            this.races.Add(model);
        }

        IReadOnlyCollection<IRace> IRepository<IRace>.GetAll()
        {
            return (IReadOnlyCollection<IRace>)this.races;
        }

        IRace IRepository<IRace>.GetByName(string name)
        {
            return this.races.Where(r => r.Name == name).FirstOrDefault();
        }

        bool IRepository<IRace>.Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
