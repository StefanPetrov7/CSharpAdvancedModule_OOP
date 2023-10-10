using System;
namespace Explicit_Interfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
       
    }
}

