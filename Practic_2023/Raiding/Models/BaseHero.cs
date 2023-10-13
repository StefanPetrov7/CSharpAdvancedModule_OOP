using System;
namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            this.Name = name;
        }

        public abstract int Power { get; }

        public string Name { get; private set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name}";
        }

    }
}

