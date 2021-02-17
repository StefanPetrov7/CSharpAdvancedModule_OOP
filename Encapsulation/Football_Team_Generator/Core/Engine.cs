using System;
using System.Collections.Generic;
using System.Linq;

using Football_Team_Generator.Models;

namespace Football_Team_Generator.Core
{
    public class Engine
    {
        private const string END_INPUT = "END";
        private const string NO_SUCH_TEAM = "Team {0} does not exist.";

        private readonly ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != END_INPUT)
            {
                string[] arg = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string cmd = arg[0];
                string teamName = arg[1];

                try
                {
                    switch (cmd)
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            if (IsTeamExist(teamName))
                            {
                                continue;
                            }
                            else
                            {
                                teams.Add(team);
                            }
                            break;

                        case "Add":
                            if (IsTeamExist(teamName))
                            {
                                Player player = new Player(arg[2], int.Parse(arg[3]), int.Parse(arg[4]),
                                           int.Parse(arg[5]), int.Parse(arg[6]), int.Parse(arg[7]));
                                teams.FirstOrDefault(t => t.Name == teamName).AddPlayer(player);
                            }
                            else
                            {
                                throw new ArgumentException(string.Format(NO_SUCH_TEAM, teamName));
                            }
                            break;

                        case "Remove":
                            string playerName = arg[2];
                            if (IsTeamExist(teamName))
                            {
                                teams.FirstOrDefault(t => t.Name == teamName).RemovePlayer(playerName);
                            }
                            else
                            {
                                throw new ArgumentException(string.Format(NO_SUCH_TEAM, teamName));
                            }
                            break;

                        case "Rating":
                            if (IsTeamExist(teamName))
                            {
                                Console.WriteLine(teams.FirstOrDefault(t => t.Name == teamName).ToString());
                            }
                            else
                            {
                                throw new ArgumentException(string.Format(NO_SUCH_TEAM, teamName));
                            }
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        public bool IsTeamExist(string teamName) => teams.Any(t => t.Name == teamName);
    }
}
