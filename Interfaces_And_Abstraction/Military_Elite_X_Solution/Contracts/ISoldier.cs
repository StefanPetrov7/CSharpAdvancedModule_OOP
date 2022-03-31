using System;
namespace Military_Elite.Contracts
{
    public interface ISoldier
    {
        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
