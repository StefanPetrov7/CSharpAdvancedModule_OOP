using System;
using System.Collections.Generic;
using System.Linq;
using Counter_Strike.Repositories.Contracts;

namespace Counter_Strike.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;

        public Repository() 
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models // => (IReadOnlyCollection<IGun>)this.guns; Another way of implementing.
        {
            get
            {
                return this.models.AsReadOnly();
            }
        }

        public void Add(T model)
        {
            if (model == null)
            {
                throw new ArgumentException(GetNullModelValidationMessage());
            }
            this.models.Add(model);
        }
          
        public T FindByName(string name)
        {
            return this.models.FirstOrDefault(FindByNameDeligate(name));
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }

        protected abstract string GetNullModelValidationMessage();
        protected abstract Func<T, bool> FindByNameDeligate(string name); 
    }
}
