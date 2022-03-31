using System;
using System.Collections.Generic;
using Military_Elite.Models;

namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate @private);
    }
}
