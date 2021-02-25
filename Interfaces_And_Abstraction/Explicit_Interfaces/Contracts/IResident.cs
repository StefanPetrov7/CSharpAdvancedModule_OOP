namespace Explicit_Interfaces.Contracts
{
    public interface IResident
    {
        public string Name { get; }

        public string Country { get;  }

        string GetName(); 
    }
}
