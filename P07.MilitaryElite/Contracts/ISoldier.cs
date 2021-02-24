namespace P07.MilitaryElite.Contracts
{
    public interface ISoldier
    {
        int Id { get; }   // highest level of encapsulation. If we know that the set will not be done from outside.
        string FirstName { get; }
        string LastName { get; }
    }
}
