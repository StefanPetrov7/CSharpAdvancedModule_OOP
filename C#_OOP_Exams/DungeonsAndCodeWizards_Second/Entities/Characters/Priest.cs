using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double baseHealth = 50;
        private const double baseArmor = 25;
        private const double baseAbilityPoints = 40;

        public Priest(string name) : base(name, baseHealth, baseArmor, baseAbilityPoints, new Backpack())
        { }

        public void Heal(Character character)
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
                character.Health += this.AbilityPoints;

                if (character.Health > character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
        }
    }
}
