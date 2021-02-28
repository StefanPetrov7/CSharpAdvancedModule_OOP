using System;
namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;

        public Druid(string name) : base(name)
        {
        }

        public override int Power => POWER;

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {this.Power}";
        }
    }
}
