using System;
using Handball.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
	public class TeamRepository : IRepository<ITeam>
	{
        private readonly IDictionary<string, ITeam> models;

        public TeamRepository()
        {
            this.models = new Dictionary<string, ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => this.models.Values.ToList().AsReadOnly();

        public void AddModel(ITeam model)
        {
            this.models[model.Name] = model;
        }

        public bool ExistsModel(string name) => this.models.ContainsKey(name);

        public ITeam GetModel(string name)
        {
            ITeam team = null;

            if (this.models.ContainsKey(name))
            {
                team = this.models[name];
                return team;
            }
            return team;
        }

        public bool RemoveModel(string name)
        {
            if (this.models.ContainsKey(name))
            {
                this.models.Remove(name);
                return true;
            }
            return false;
        }
    }
}

