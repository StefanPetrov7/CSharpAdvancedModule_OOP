using System;
using System.Collections.Generic;
using Military_Elite.Models;

namespace Military_Elite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Mission> Missions { get; }
    }
}
