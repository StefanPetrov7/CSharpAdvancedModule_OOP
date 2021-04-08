using System;

using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories
{
    public class CarRepository : Repository<ICar>
    {
        protected override Func<ICar, bool> FindByNameDelegate(string name)
        {
            return x => x.Model == name;
        }
    }
}
