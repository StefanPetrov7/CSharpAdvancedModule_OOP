using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        private ICollection<ITeamMember> _models;

        public MemberRepository()
        {
            this._models = new HashSet<ITeamMember>();
        }
        public IReadOnlyCollection<ITeamMember> Models => (IReadOnlyCollection<ITeamMember>)this._models;

        public void Add(ITeamMember model)
        {
            this._models.Add(model);
        }

        public ITeamMember TakeOne(string modelName) => this.Models.FirstOrDefault(x => x.Name == modelName);
    }
}
