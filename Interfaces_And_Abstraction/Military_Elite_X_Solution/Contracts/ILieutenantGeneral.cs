using System;
using System.Collections.Generic;
using Military_Elite.Models;

namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public HashSet<Private> Privates { get; }
    }
}
