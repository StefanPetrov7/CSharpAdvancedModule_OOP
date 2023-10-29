using System;
using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly IDictionary<string, IPlayer> models;

        public PlayerRepository()
        {
            this.models = new Dictionary<string, IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.models.Values.ToList().AsReadOnly();

        public void AddModel(IPlayer model)
        {
            this.models[model.Name] = model;
        }

        public bool ExistsModel(string name) => this.models.ContainsKey(name);

        public IPlayer GetModel(string name)
        {
            IPlayer player = null;

            if (this.models.ContainsKey(name))
            {
                player = this.models[name];
                return player;
            }
            return player;
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

