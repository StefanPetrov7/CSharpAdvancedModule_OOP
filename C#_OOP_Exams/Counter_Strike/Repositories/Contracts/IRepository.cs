using System.Collections.Generic;

namespace Counter_Strike.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T Model);

        bool Remove(T Model);

        T FindByName(string name);
    }
}
