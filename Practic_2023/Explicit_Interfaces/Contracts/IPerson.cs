using System;
namespace Explicit_Interfaces.Contracts
{
    public interface IPerson
    {
        string Name { get;  }

        int Age { get; }

        string GetName();
    }
}

