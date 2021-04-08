using System;
using System.Linq;
using System.Collections.Generic;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> collection;

        public Repository()
        {
            this.collection = new List<T>();
        }

        public void Add(T model)
        {
            this.collection.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)this.collection;
        }

        public T GetByName(string name)
        {
            return this.collection.FirstOrDefault(FindByNameDelegate(name));
        }

        public bool Remove(T model)
        {
            return this.collection.Remove(model);
        }

        protected abstract Func<T, bool> FindByNameDelegate(string name); 
    }
}
