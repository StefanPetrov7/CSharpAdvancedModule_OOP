using System;

using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories
{
    public class DriverRepository : Repository<IDriver>
    {
        protected override Func<IDriver, bool> FindByNameDelegate(string name)
        {
            return x => x.Name == name;
        }
    }
}
