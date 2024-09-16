using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        private const string MASTER = "Master";

        public TeamLead(string name, string path) : base(name, path)
        {
        }

        public override string Path
        {
            get
            {
                return this._path;
            }
            protected set
            {
                if (value != MASTER)
                    throw new AbandonedMutexException(string.Format(ExceptionMessages.PathIncorrect, value));
                this._path = value;
            }
        }

        public override string ToString() => $"{this.Name} ({this.GetType().Name}) – Currently working on {this.InProgress.Count} tasks.";
    }
}
