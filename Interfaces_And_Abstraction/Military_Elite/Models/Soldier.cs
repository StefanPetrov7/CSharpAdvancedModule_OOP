using System;

using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class Soldier : ISoldier
    {

        public Soldier(int iD, string firstName, string lastName)
        {
            this.ID = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual int ID { get; private set; }
        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }

    }
}
