using System;
using System.Collections.Generic;
using Military_Elite.Models;

namespace Military_Elite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Repair> Repairs { get; }

    }
}
