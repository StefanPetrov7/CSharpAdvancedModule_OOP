using System;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int weight = 5;
        private const int healing_points_decrease = 5;

        public FirePotion() : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= healing_points_decrease;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
