using System;
using System.Linq;
using System.Reflection;
using HAD.Contracts;
using HAD.Core.Factory.Contracts;
using HAD.Entities.Heroes;

namespace HAD.Core.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroType, string name)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == heroType);
            IHero hero = (BaseHero)Activator.CreateInstance(type, new object[] { name });
            return hero;
        }
    }
}
