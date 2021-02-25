using System.Collections.Generic;

namespace P07.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        public void AddRepair(IRepair repair);
    }
}
