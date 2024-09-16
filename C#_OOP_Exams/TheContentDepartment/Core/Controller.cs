using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {

        private IRepository<IResource> resources;
        private IRepository<ITeamMember> members;
        private ICollection<string> teamTypes = new HashSet<string>() { "TeamLead", "ContentMember" };
        private ICollection<string> resourceTypes = new HashSet<string>() { "Exam", "Workshop", "Presentation" };


        public Controller()
        {
            this.resources = new ResourceRepository();
            this.members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = this.resources.TakeOne(resourceName);

            if (resource.IsTested == false)
                return $"{resourceName} cannot be approved without being tested.";

            ITeamMember teamLead = this.members.Models.FirstOrDefault(m => m.GetType().Name == "TeamLead");

            if (isApprovedByTeamLead == true)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);
                return $"{teamLead.Name} approved {resourceName}.";
            }
            else
            {
                resource.Test();
                return $"{teamLead.Name} returned {resourceName} for a re-test.";
            }
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (!this.resourceTypes.Contains(resourceType))
                return $"{resourceType} type is not handled by Content Department.";

            if (!this.members.Models.Any(x => x.Path == path))
                return $"No content member is able to create the {resourceName} resource.";

            if (this.members.Models.FirstOrDefault(x => x.Path == path).InProgress.Contains(resourceName) == true)
                return $"The {resourceName} resource is being created.";

            ITeamMember teamMember = this.members.Models.FirstOrDefault(x => x.GetType().Name == "ContentMember" && x.Path == path);

            IResource resource = resourceType switch
            {
                "Exam" => new Exam(resourceName, teamMember.Name),
                "Presentation" => new Presentation(resourceName, teamMember.Name),
                "Workshop" => new Workshop(resourceName, teamMember.Name)
            };

            teamMember.WorkOnTask(resourceName);
            this.resources.Add(resource);
            return $"{teamMember.Name} created {resourceType} - {resourceName}.";
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Finished Tasks:");

            foreach (var resource in this.resources.Models.Where(x => x.IsApproved == true))
            {
                sb.AppendLine($"--{resource.ToString()}");
            }

            ITeamMember teamLead = this.members.Models.FirstOrDefault(x => x.GetType().Name == "TeamLead");

            sb.AppendLine("Team Report:");
            sb.AppendLine($"--{teamLead.Name} (TeamLead) - Currently working on {teamLead.InProgress.Count} tasks.");

            foreach (var contentMember in this.members.Models.Where(x => x.GetType().Name == "ContentMember"))
            {
                sb.AppendLine($"{contentMember.Name} - {contentMember.Path} path. Currently working on {contentMember.InProgress.Count} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (!this.teamTypes.Contains(memberType))
                return $"{memberType} is not a valid member type.";

            if (this.members.Models.Any(x => x.GetType().Name == "ContentMember" && x.Path == path))
                return $"Position is occupied.";

            if (this.members.Models.Any(x => x.Name == memberName))
                return $"{memberName} has already joined the team.";

            ITeamMember member = memberType switch
            {
                "TeamLead" => new TeamLead(memberName, path),
                "ContentMember" => new ContentMember(memberName, path),
            };

            this.members.Add(member);
            return $"{memberName} has joined the team. Welcome!";
        }

        public string LogTesting(string memberName)
        {
            ITeamMember teamMember = this.members.TakeOne(memberName);

            if (teamMember == null || teamMember.GetType().Name == "TeamLead")
                return $"Provide the correct member name.";

            IResource resource = this.resources.Models.Where(x => x.IsTested == false && x.Creator == teamMember.Name).OrderBy(x => x.Priority).FirstOrDefault();

            if (resource == null)
                return $"{memberName} has no resources for testing.";

            ITeamMember teamLead = this.members.Models.FirstOrDefault(x => x.GetType().Name == "TeamLead");

            if (teamLead == null)
                return "No Team lead in the members list => not a task request => added additional by me";

            teamMember.FinishTask(resource.Name);
            resource.Test();
            teamLead.WorkOnTask(resource.Name);
            return $"{resource.Name} is tested and ready for approval.";
        }
    }
}
