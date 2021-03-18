using System.Collections.Generic;
using System.Linq;
using Counter_Strike.Models.Maps.Contracts;
using Counter_Strike.Models.Players;
using Counter_Strike.Models.Players.Contracts;

namespace Counter_Strike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;


        public Map()
        {
            this.terrorists = new List<Players.Contracts.IPlayer>();
            this.counterTerrorists = new List<Players.Contracts.IPlayer>();
        }


        public string Strat(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while (IsTeamAlive(terrorists) && IsTeamAlive(counterTerrorists))
            {
                AttackTeam(terrorists, counterTerrorists);
                AttackTeam(counterTerrorists, terrorists);
            }

            if (IsTeamAlive(terrorists))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }

        }

        // => Different approuch

        //private ICollection<Terrorist> terrorists;
        //private ICollection<CounterTerrorist> counterTerrorists;

        //public Map()
        //{
        //    this.terrorists = new List<Terrorist>();
        //    this.counterTerrorists = new List<CounterTerrorist>();
        //}

        //public string Strat(ICollection<IPlayer> players)
        //{
        //    this.terrorists = players.Where(p => p.GetType().Name == "Terrorist").Select(p => (Terrorist)p).ToList();
        //    this.counterTerrorists = players.Where(p => p.GetType().Name == "CounterTerrorist").Select(p => (CounterTerrorist)p).ToList();


        //    bool isAllTErroristDead = false;
        //    bool isAllCounterTerroristsAreDead = false;

        //    while (isAllCounterTerroristsAreDead == true || isAllTErroristDead == true)
        //    {
        //        foreach (Terrorist terrorist in this.terrorists)
        //        {
        //            if (!terrorist.isAlive) continue;  // need to be checked, if the dead ones are shooting.
        //            foreach (CounterTerrorist counterTerrorist in this.counterTerrorists)
        //            {
        //                if (counterTerrorist.isAlive)
        //                {
        //                    counterTerrorist.TakeDamage(terrorist.Gun.Fire());
        //                }
        //            }
        //        }

        //        foreach (CounterTerrorist counterTerrorist in this.counterTerrorists)
        //        {
        //            if (!counterTerrorist.isAlive) continue;
        //            foreach (Terrorist terrorist in this.terrorists)
        //            {
        //                if (terrorist.isAlive)
        //                {
        //                    terrorist.TakeDamage(counterTerrorist.Gun.Fire());
        //                }
        //            }
        //        }

        //        isAllTErroristDead = true;
        //        foreach (Terrorist terrorist in this.terrorists)
        //        {
        //            if (terrorist.isAlive)
        //            {
        //                isAllTErroristDead = false;
        //                break;
        //            }
        //        }

        //        isAllCounterTerroristsAreDead = true;
        //        foreach (CounterTerrorist counterTerrorist in this.counterTerrorists)
        //        {
        //            if (counterTerrorist.isAlive)
        //            {
        //                isAllCounterTerroristsAreDead = false;
        //                break;
        //            }
        //        }
        //    }

        //    return isAllTErroristDead ? "Counter Terrorist wins" : "Terrorist wins";
        //}

        private void SeparateTeams(ICollection<Players.Contracts.IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is CounterTerrorist)
                {
                    this.counterTerrorists.Add(player);
                }
                else
                {
                    this.terrorists.Add(player);
                }
            }
        }

        private void AttackTeam(List<Players.Contracts.IPlayer> attackingTeam, List<Players.Contracts.IPlayer> defendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
                if (!attacker.isAlive) continue;

                foreach (var defender in defendingTeam)
                {
                    if (defender.isAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

        private bool IsTeamAlive(List<Players.Contracts.IPlayer> players)
        {
            return players.Any(p => p.isAlive);
        }
    }
}

