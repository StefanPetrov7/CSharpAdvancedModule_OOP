using System;
namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;

        public Warrior(string name) : base(name)
        {
        }

        public override int Power => POWER;

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {this.Power} damage";
        }
    }
}
