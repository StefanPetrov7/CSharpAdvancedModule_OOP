using System;
using Practice.Contracts;
using Practice.Enumerations;
using Practice.Exceptions;

namespace Practice.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string statusStr)
        {
            this.CodeName = codeName;
            this.MissionState = TryParseMissionState(statusStr);
        }

        private MissionState TryParseMissionState(string statusStr)
        {
            MissionState state;
            bool isParsed = Enum.TryParse<MissionState>(statusStr, out state);

            if (!isParsed)
            {
                throw new InvalidMissionStateMessage();
            }

            return state;
        }

        public string CodeName { get; private set; }

        public MissionState MissionState { get; private set; }

        public void CompleteMission()
        {
            this.MissionState = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.MissionState}";
        }
    }
}
