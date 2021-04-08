using System;

using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        protected override Func<IRace, bool> FindByNameDelegate(string name)
        {
            return x => x.Name == name;
        }
    }
}
