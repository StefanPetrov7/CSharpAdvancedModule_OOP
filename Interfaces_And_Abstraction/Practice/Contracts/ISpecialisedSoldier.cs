using Practice.Enumerations;

namespace Practice.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}

