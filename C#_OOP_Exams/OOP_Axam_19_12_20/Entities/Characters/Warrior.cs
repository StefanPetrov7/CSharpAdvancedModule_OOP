using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private double baseHealth = 100;
        private double baseArmor = 50;
        private double abillityPoints = 40;

        public Warrior(string name)
            : base(name)
        {
            base.Bag = new Satchel();
        }

        public override double BaseHealth => baseHealth;

        public override double Health
        {
            get { return this.baseHealth; }
            set { baseHealth = value; }
        }

        public override double BaseArmor => baseArmor;

        public override double Armor
        {
            get { return this.baseArmor; }
            set { baseArmor = value; }  
        }

        public override double AbilityPoints => abillityPoints;

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);
            }
            else if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
        }
    }
}
