using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character , IAttacker
    {
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double baseAbilityPoints = 40;

        public Warrior(string name) : base(name, baseHealth, baseArmor, baseAbilityPoints, new Satchel())
        { }

        public void Attack(Character character)   
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            else if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            else
            {
                if (this == character)  
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
