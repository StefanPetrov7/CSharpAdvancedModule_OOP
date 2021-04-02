using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double warriorBaseHealth = 100;
        private const double warriorBaseArmor = 50;
        private const double warriorBaseAbility = 40;

        public Warrior(string name)
            : base(name, warriorBaseHealth, warriorBaseArmor, warriorBaseAbility, new Satchel())
        { }

        public void Attack(Character character)
        {
            this.EnsureAlive();   // First check

            if (this == character)  // Second check
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            
            character.TakeDamage(this.AbilityPoints);  // Third check is in the TakeDamage method.

        }
    }   
}
