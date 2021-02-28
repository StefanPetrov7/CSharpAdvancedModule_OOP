using System.Collections.Generic;
using Raiding.Common;
using Raiding.Contracts;
using Raiding.Exceptions;
using Raiding.Factory;
using Raiding.Models;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private const int ZERO = 0;

        IWriter writer;
        IReader reader;
        HeroFactory heroFactory = new HeroFactory();
        public ICollection<BaseHero> heroes;

        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            while (heroes.Count < n)
            {
                try
                {
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();
                    heroes.Add(heroFactory.GetHero(name, type));
                }
                catch (InvalideHeroException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int totalPpwer = ZERO;

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                totalPpwer += hero.Power;
            }

            string result = totalPpwer >= bossPower ? GlobalConstants.VICTORY : GlobalConstants.DEFEAT;
            writer.WriteLine(result);

        }
    }
}
