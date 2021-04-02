using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int healthWeight = 5;
        private const int healthDecrease = 20;

        public FirePotion() : base(healthWeight)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= healthDecrease;

            if (character.Health < 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
