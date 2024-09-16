using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string _name;
        protected string _path;
        private ICollection<string> _inProgress;

        protected TeamMember(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            this._inProgress = new HashSet<string>();   ;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhiteSpace));
                _name = value;
            }
        }

        public virtual string Path { get; protected set; }

        public IReadOnlyCollection<string> InProgress => (IReadOnlyCollection<string>)_inProgress;

        public void FinishTask(string resourceName)
        {
            this._inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            this._inProgress.Add(resourceName);
        }
    }
}
