using System.Collections.Generic;

namespace P07.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; } // IReadOnly to avoid changes to the collection from outside.

        void AddPrivate(ISoldier @private);
    }
}
