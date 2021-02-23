using System.Collections.Generic;

namespace Military_Elite.Contracts
{
    public interface IEngineer
    {
        public Dictionary<string, int> Repairs { get; }
    }
}
