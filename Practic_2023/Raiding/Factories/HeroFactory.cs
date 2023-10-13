using Raiding.Enumerations;
using Raiding.Models;
using Raiding.Exceptions;

namespace Raiding.Factories
{
    public static class HeroFactory
    {
        public static BaseHero GetHero(string name, string type)
        {
            BaseHero hero = null;

            if (EnumParse(type) == HeroType.Druid)
            {
                hero = new Druid(name);
            }
            else if (EnumParse(type) == HeroType.Paladin)
            {
                hero = new Paladin(name);
            }
            else if (EnumParse(type) == HeroType.Warrior)
            {
                hero = new Warrior(name);
            }
            else if (EnumParse(type) == HeroType.Rogue)
            {
                hero = new Rogue(name);
            }

            return hero;
        }

        public static HeroType EnumParse(string type)
        {
            if (Enum.TryParse<HeroType>(type, out HeroType curType))
            {
                return curType;
            }

            throw new InvalidHeroException();

        }
    }
}

