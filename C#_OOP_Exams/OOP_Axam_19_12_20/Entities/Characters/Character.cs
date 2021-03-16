using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Models;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;

        protected Character(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
                }

                this.name = value;
            }
        }

        public virtual double BaseHealth { get; set; }

        public virtual double Health { get; set; }

        public virtual double BaseArmor { get; set; }

        public virtual double Armor { get; set; }

        public virtual double AbilityPoints { get; set; }

        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive == true)
            {
                if (hitPoints > this.Armor)
                {
                    hitPoints -= this.Armor;
                    this.Armor = 0;
                    this.Health -= hitPoints;

                    if (this.Health <= 0)
                    {
                        IsAlive = false;
                    }
                }
                else
                {
                    this.Armor -= hitPoints;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive == true)
            {
                item.AffectCharacter(this);
            }
        }
    }
}