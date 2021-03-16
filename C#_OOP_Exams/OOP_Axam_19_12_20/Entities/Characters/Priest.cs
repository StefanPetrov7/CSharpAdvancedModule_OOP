using System;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters
{
    public class Priest :Character, IHealer
    {
        private double baseHealth = 50;
        private double baseArmor = 25;
        private double abillityPoints = 40;

        public Priest(string name) : base(name)
        {
            base.Bag = new Backpack();
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

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;

                if (character.Health > character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
        }
    }
}
