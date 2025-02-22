using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Repositories.Contracts;
using FootballManager.Utilities.Messages;
using System.Text;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private IRepository<ITeam> teamRepository;
        private ICollection<string> managerTypes = new HashSet<string>()
        {
            "AmateurManager",
            "SeniorManager",
            "ProfessionalManager"
        };

        public Controller()
        {
            this.teamRepository = new TeamRepository();
        }

        public string JoinChampionship(string teamName)
        {
            if (this.teamRepository.Models.Count == this.teamRepository.Capacity)
                return OutputMessages.ChampionshipFull;

            if (this.teamRepository.Exists(teamName))
                return String.Format(OutputMessages.TeamWithSameNameExisting, teamName);

            ITeam team = new Team(teamName);
            this.teamRepository.Add(team);
            return String.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            if (this.teamRepository.Exists(teamOneName) == false || this.teamRepository.Exists(teamTwoName) == false)
                return OutputMessages.OneOfTheTeamDoesNotExist;

            ITeam teamOne = this.teamRepository.Get(teamOneName);
            ITeam teamTwo = this.teamRepository.Get(teamTwoName);

            if (teamOne.PresentCondition > teamTwo.PresentCondition)
            {
                teamOne.GainPoints(3);

                if (teamOne.TeamManager != null)
                    teamOne.TeamManager.RankingUpdate(5);

                if (teamTwo.TeamManager != null)
                    teamTwo.TeamManager.RankingUpdate(-5);

                return String.Format(OutputMessages.TeamWinsMatch, teamOneName, teamTwoName);
            }
            else if (teamTwo.PresentCondition > teamOne.PresentCondition)
            {
                teamTwo.GainPoints(3);

                if (teamTwo.TeamManager != null)
                    teamTwo.TeamManager.RankingUpdate(5);

                if (teamOne.TeamManager != null)
                    teamOne.TeamManager.RankingUpdate(-5);

                return String.Format(OutputMessages.TeamWinsMatch, teamTwoName, teamOneName);
            }
            else
            {
                teamOne.GainPoints(1);
                teamTwo.GainPoints(1);
                return String.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
            }
        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {

            if (this.teamRepository.Exists(droppingTeamName) == false)         
                return String.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);


            if (this.teamRepository.Exists(promotingTeamName))
                return String.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);

            ITeam promotingTeam = new Team(promotingTeamName);


            if (this.managerTypes.Contains(managerTypeName))  // Checking if the same manager is the championship or his type is valid
            {
                if (this.teamRepository.Models.Any(x => x.TeamManager.Name == managerName) == false)
                {
                    IManager manager = managerTypeName switch
                    {
                        "AmateurManager" => new AmateurManager(managerName),
                        "SeniorManager" => new SeniorManager(managerName),
                        "ProfessionalManager" => new ProfessionalManager(managerName),
                    };

                    promotingTeam.SignWith(manager);
                }
            }

            foreach (var team in this.teamRepository.Models)
            {
                team.ResetPoints();
            }

            this.teamRepository.Remove(droppingTeamName);

            this.teamRepository.Add(promotingTeam);
            return String.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!this.teamRepository.Exists(teamName))
                return String.Format(OutputMessages.TeamDoesNotTakePart, teamName);

            if (!this.managerTypes.Contains(managerTypeName))
                return String.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);

            if (this.teamRepository.Get(teamName).TeamManager != null)
            {
                string curManager = this.teamRepository.Get(teamName).TeamManager.Name;
                return String.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, curManager);
            }

            if (this.teamRepository.Models.Any(x => x.TeamManager?.Name == managerName))
                return String.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);

            IManager manager = managerTypeName switch
            {
                "AmateurManager" => new AmateurManager(managerName),
                "SeniorManager" => new SeniorManager(managerName),
                "ProfessionalManager" => new ProfessionalManager(managerName),
            };

            this.teamRepository.Models.FirstOrDefault(x => x.Name == teamName).SignWith(manager);

            return String.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
        }

        public string ChampionshipRankings()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("***Ranking Table***");
            int ranking = 1;

            foreach (var team in this.teamRepository.Models.OrderByDescending(x => x.ChampionshipPoints).ThenByDescending(x => x.PresentCondition))
            {
                result.AppendLine($"{ranking}. {team.ToString()}/{team.TeamManager.ToString()}");
                ranking++;
            }

            return result.ToString().TrimEnd();
        }
    }
}
