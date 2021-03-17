using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double abillityPoints = 40;

        public Warrior(string name)
            : base(name)
        {
            this.Health = baseHealth;
            this.Armor = baseArmor;
            base.Bag = new Satchel();
        }

        public override double BaseHealth => baseHealth;

        public override double Health { get; set; }

        public override double BaseArmor => baseArmor;

        public override double Armor { get; set; }

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
