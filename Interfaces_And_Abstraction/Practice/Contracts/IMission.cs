using System;
using Practice.Enumerations;

namespace Practice.Contracts
{
    public interface IMission
    {
        public string CodeName { get;  }

        public MissionState MissionState { get;  }

        void CompleteMission();

    }
}
