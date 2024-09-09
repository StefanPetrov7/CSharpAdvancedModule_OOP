using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private ICollection<IFish> fishes;

        public FishRepository()
        {
            this.fishes = new HashSet<IFish>();
        }
        public IReadOnlyCollection<IFish> Models => (IReadOnlyCollection<IFish>)this.fishes;

        public void AddModel(IFish model)
        {
            this.fishes.Add(model);
        }

        public IFish GetModel(string name) => this.fishes.FirstOrDefault(f => f.Name == name);

    }
}
