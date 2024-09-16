using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        private ICollection<IResource> _models;

        public ResourceRepository()
        {
            this._models = new HashSet<IResource>();
        }
        public IReadOnlyCollection<IResource> Models => (IReadOnlyCollection<IResource>)this._models;

        public void Add(IResource model)
        {
            this._models.Add(model);
        }

        public IResource TakeOne(string modelName) => this.Models.FirstOrDefault(x => x.Name == modelName);

    }
}
