using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int setWeight = 5;
        private const int increasePoints = 20;

        public HealthPotion() : base(setWeight)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += increasePoints;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
