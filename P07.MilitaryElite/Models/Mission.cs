using System;

using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Enumerations;
using P07.MilitaryElite.Exceptions;

namespace P07.MilitaryElite.Models
{
    public class Mission : IMission
    {

        public Mission(string codeName, string status)
        {
            this.CodeName = codeName;
            this.Status = TryParseStatus(status);
        }

        private MissionStatus TryParseStatus(string statusStr)
        {
            MissionStatus status;
            bool isParsed = Enum.TryParse<MissionStatus>(statusStr, out status);

            if (!isParsed)
            {
                throw new InvalidStatusException();
            }

            return status;
        }

        public string CodeName { get; private set; }

        public MissionStatus Status { get; private set; }

        public void CompleteMission()
        {
            if (this.Status == MissionStatus.Finished)
            {
                throw new MissionStatusFinishedException();
            }

            this.Status = MissionStatus.Finished;
        }

        public override string ToString()
        {
            return  $"  Code Name: {this.CodeName} State: {this.Status.ToString()}";
        }
    }
}
