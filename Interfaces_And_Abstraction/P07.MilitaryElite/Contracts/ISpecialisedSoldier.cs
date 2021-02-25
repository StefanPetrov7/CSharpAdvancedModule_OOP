using P07.MilitaryElite.Enumerations;

namespace P07.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; } // Using Enum instead of string.
    }
}
