using System;
using Military_Elite.Enumerations;

namespace Military_Elite.Contracts
{
    public interface ISpecialisedSoldier: IPrivate
    {
        public Corps Corp { get; }
    }
}
