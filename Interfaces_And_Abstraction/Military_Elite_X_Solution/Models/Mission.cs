using System;
using Military_Elite.Enumerations;
using Military_Elite.Validators;

namespace Military_Elite.Models
{
    public class Mission
    {
        public Mission(string name, string strProgress)
        {
            this.Name = name;
            this.MissionProgress = EnumValidator.ValidateProgress(strProgress);
        }

        public string Name { get; private set; }

        public Progress MissionProgress { get; set; }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.MissionProgress}";
        }
    }
}
