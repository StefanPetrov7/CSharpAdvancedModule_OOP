using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double priestBaseHealth = 50;
        private const double priestBaseArmor = 25;
        private const double priestBaseAbility = 40;

        public Priest(string name)
            : base(name, priestBaseHealth, priestBaseArmor, priestBaseAbility, new Backpack())
        { }

        public void Heal(Character character)
        {
            this.EnsureAlive(); 

            if (!character.IsAlive) 
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
