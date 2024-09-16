using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        private ICollection<string> pathValues = new HashSet<string>() { "CSharp", "JavaScript", "Python", "Java" };
        public ContentMember(string name, string path) : base(name, path)
        {
        }

        public override string Path
        {
            get => this._path;
            protected set
            {
                if (!pathValues.Contains(value))
                    throw new ArgumentException(String.Format(ExceptionMessages.PathIncorrect, value));
                this._path = value;
            }
        }

        public override string ToString() => $"{this.Name} - {this.Path} path. Currently working on {this.InProgress.Count} tasks.";

    }
}
