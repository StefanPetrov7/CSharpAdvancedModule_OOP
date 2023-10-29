using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;
        private List<string> playersTypes = new List<string>
        {
            "Goalkeeper",
            "CenterBack",
            "ForwardWing"
        };

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            foreach (var team in this.teams.Models   // Not checking if there is any teams in the repository!
                .OrderByDescending(x => x.PointsEarned)
                .ThenByDescending(x => x.OverallRating)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = this.players.GetModel(playerName);
            ITeam team = this.teams.GetModel(teamName);

            if (player == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, this.players.GetType().Name);
            }

            if (team == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, this.teams.GetType().Name);
            }

            if (player.Team != null) // check what is returning if it is not assigned
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(team.Name);
            team.SignContract(player);  // We are not checking if this team alreay has this player or if he is a Goalkeep, as it could be only one!
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this.teams.GetModel(firstTeamName);
            ITeam secondTeam = this.teams.GetModel(secondTeamName);

            double firstTeamRaiting = firstTeam.OverallRating;
            double secondTeamRaiting = secondTeam.OverallRating;

            if (firstTeamRaiting > secondTeamRaiting)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (secondTeamRaiting > firstTeamRaiting)
            {
                secondTeam.Win();
                firstTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }
            else
            {
                secondTeam.Draw();
                firstTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = this.players.GetModel(name);

            if (playersTypes.Contains(typeName) == false)
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (player != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, this.players.GetType().Name, player.GetType().Name);
            }

            if (typeName == typeof(Goalkeeper).Name)
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == typeof(ForwardWing).Name)
            {
                player = new ForwardWing(name);
            }
            else
            {
                player = new CenterBack(name);
            }

            this.players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            ITeam team = this.teams.GetModel(name);

            if (team == null)
            {
                team = new Team(name);
                this.teams.AddModel(team);
                return string.Format(OutputMessages.TeamSuccessfullyAdded, name, this.teams.GetType().Name);
            }

            return string.Format(OutputMessages.TeamAlreadyExists, name, this.teams.GetType().Name);
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = this.teams.GetModel(teamName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");

            if (team.Players.Count > 0)
            {
                foreach (var player in team.Players.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().TrimEnd();

        }
    }
}