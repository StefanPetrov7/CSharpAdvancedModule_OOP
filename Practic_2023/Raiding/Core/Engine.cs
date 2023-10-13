using Raiding.Exceptions;
using Raiding.Contracts;
using Raiding.Models;
using Raiding.Factories;
namespace Raiding.Core
{
    public class Engine
    {
        private const string VICTORY = "Victory!";
        private const string DEFEAT = "Defeat...";

        private IWriter writer;
        private IReader reader;
        private ICollection<BaseHero> heroes;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroes = new List<BaseHero>();
        }

        public void RunHero()
        {
            int n = int.Parse(reader.Read());

            // While cycle to be used as if heroes is not N it will not give 100 PTS. !!!!!!!!!!

            while (this.heroes.Count < n) 
            {
                string name = reader.Read();
                string type = reader.Read();

                try
                {
                    this.heroes.Add(HeroFactory.GetHero(name, type));
                }
                catch (InvalidHeroException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            int bossHealth = int.Parse(reader.Read());
            int heroesPower = this.heroes.Count > 0 ? this.heroes.Sum(x => x.Power) : 0;

            foreach (var hero in this.heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            string gameResult = heroesPower >= bossHealth ? VICTORY : DEFEAT;

            writer.WriteLine(gameResult);
        }
    }
}

