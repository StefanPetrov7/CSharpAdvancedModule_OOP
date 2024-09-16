using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string _name;

        protected Resource(string name, string creator, int priority)
        {
            this.Name = name;
            this.Creator = creator; 
            this.Priority = priority;
            this.IsTested = false;
            this.IsApproved = false;
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

        public string Creator { get; private set; }

        public int Priority { get; private set; }

        public bool IsTested { get; private set; }

        public bool IsApproved { get; private set; }


        public void Approve()
        {
            this.IsApproved = true;
        }

        public void Test()
        {
            this.IsTested = !this.IsTested;
        }

        public override string ToString() => $"{this.Name} ({this.GetType().Name}), Created By: {this.Creator}";

    }
}
