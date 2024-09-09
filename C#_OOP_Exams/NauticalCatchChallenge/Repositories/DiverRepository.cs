using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private ICollection<IDiver> divers;

        public DiverRepository()
        {
            this.divers = new HashSet<IDiver>();    
        }
        public IReadOnlyCollection<IDiver> Models => (IReadOnlyCollection<IDiver>)this.divers;

        public void AddModel(IDiver model)
        {
            this.divers.Add(model); 
        }

        public IDiver GetModel(string name) => this.divers.FirstOrDefault(d => d.Name == name);
      
    }
}
