using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private ICollection<ITeam> _models = new HashSet<ITeam>();
        private const int MAX_CAPACITY = 10;

        public IReadOnlyCollection<ITeam> Models => (IReadOnlyCollection<ITeam>)this._models;

        public int Capacity => MAX_CAPACITY;

        public void Add(ITeam model)
        {
            if (this.Models.Count == this.Capacity)
                return;
            this._models.Add(model);
        }

        public bool Exists(string name) => this.Models.Any(x => x.Name == name);

        public ITeam Get(string name) => this.Models.FirstOrDefault(x => x.Name == name);

        public bool Remove(string name)
        {
            ITeam team = this.Models.FirstOrDefault(x => x.Name == name);
            return this._models.Remove(team);
        }
    }
}
