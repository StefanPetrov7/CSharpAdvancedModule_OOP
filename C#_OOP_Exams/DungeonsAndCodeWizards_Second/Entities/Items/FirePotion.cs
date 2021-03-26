using System;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int setWeight = 5;
        private const int decreasePoints = 20;

        public FirePotion() : base(setWeight)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= decreasePoints;
        }
    }
}
