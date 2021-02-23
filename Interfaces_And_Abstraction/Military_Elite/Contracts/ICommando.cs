using System.Collections.Generic;

namespace Military_Elite.Contracts
{
    public interface ICommando
    {
        public Dictionary<string, string> Missions { get;  }

        public void CompleteMission();
    }
}

