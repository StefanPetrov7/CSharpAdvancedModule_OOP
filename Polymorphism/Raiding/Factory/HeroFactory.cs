using System;

using Raiding.Models;
using Raiding.Common;
using Raiding.Contracts;
using Raiding.Exceptions;
using Raiding.Enumeration;

namespace Raiding.Factory
{
    public class HeroFactory
    {

        public BaseHero GetHero(string name, string type)
        {
            BaseHero hero = null;

            if (CheckHeroType(type) == HeroTypes.Druid)
            {
                hero = new Druid(name);
            }
            else if (CheckHeroType(type) == HeroTypes.Paladin)
            {
                hero = new Paladin(name);
            }
            else if (CheckHeroType(type) == HeroTypes.Rogue)
            {
                hero = new Rogue(name);
            }
            else if (CheckHeroType(type) == HeroTypes.Warrior)
            {
                hero = new Warrior(name);
            }

            return hero;

        }

        public HeroTypes CheckHeroType(string type)
        {
            if (!Enum.TryParse<HeroTypes>(type, out HeroTypes currentType))
            {
                throw new InvalideHeroException();
            }
            return currentType;
        }

    }
}
