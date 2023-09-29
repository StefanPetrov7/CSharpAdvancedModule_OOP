using FootballTeamGenerator.Models;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        // TODO better for team and player to be used Dict<string, team> Dict<string, player> => better collections for this task. 

        private const string END_PROGRAM = "END";

        private const string NO_SUCH_TEAM = "Team {0} does not exist.";

        private ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != END_PROGRAM)
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string teamName = data[1];

                try
                {
                    if (data[0] == "Team")
                    {
                        Team team = new Team(teamName);

                        if (IsTeamExist(teamName))
                        {
                            continue;
                        }

                        this.teams.Add(team);
                    }
                    else if (data[0] == "Add")
                    {
                        if (IsTeamExist(teamName))
                        {
                           Player player = new Player(data[2],
                               int.Parse(data[3]), int.Parse(data[4]),
                               int.Parse(data[5]), int.Parse(data[6]),
                               int.Parse(data[7]));

                            this.teams.FirstOrDefault(t => t.Name == teamName).Add(player);
                        }
                        else
                        {
                            throw new ArgumentException(string.Format(NO_SUCH_TEAM, teamName));
                        }

                    }
                    else if (data[0] == "Remove")
                    {
                        string playerToReamove = data[2];

                        if (IsTeamExist(teamName))
                        {
                            this.teams.FirstOrDefault(t => t.Name == teamName).Remove(playerToReamove);
                        }
                        else
                        {
                            throw new ArgumentException(string.Format(NO_SUCH_TEAM, teamName));
                        }
                       
                    }
                    else if (data[0] == "Rating")
                    {
                        if (IsTeamExist(teamName))
                        {
                            Console.WriteLine(this.teams.FirstOrDefault(t=>t.Name == teamName).ToString());
                        }
                        else
                        {
                            throw new ArgumentException(string.Format(NO_SUCH_TEAM, teamName));
                        }
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

