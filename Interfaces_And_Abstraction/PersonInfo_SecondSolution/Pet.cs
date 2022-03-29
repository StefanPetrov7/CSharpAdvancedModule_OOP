using System;
namespace PersonInfo
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
