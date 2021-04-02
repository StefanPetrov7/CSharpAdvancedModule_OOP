using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseArmor = armor;
            this.BaseHealth = health;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Health = health;
            this.Armor = armor;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public bool IsAlive { get; set; } = true; 

        public double BaseHealth { get; private set; }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                this.armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;
            }

            if (this.Health <= 0)
            {
                this.Health = 0;
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);  
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            string result = $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
            return result.TrimEnd();
        }
    }
}