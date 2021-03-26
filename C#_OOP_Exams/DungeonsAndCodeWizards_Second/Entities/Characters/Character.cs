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
        private double abilityPoints;

        protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = baseHealth;
            this.BaseArmor = baseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Health = baseHealth;
            this.Armor = baseArmor;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return this.armor; }
            private set { this.armor = value; }
        }

        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            private set { this.abilityPoints = value; }
        }

        public IBag Bag { get; }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(double hitPoints)
        {

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

            if (this.Health < 0)
            {
                this.Health = 0;
            }

        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public override string ToString()
        {
            string isAlive = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {isAlive}";
        }
    }
}