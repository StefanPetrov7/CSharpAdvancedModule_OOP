using System;
using System.Collections.Generic;

using Military_Elite.Models;

namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral
    {
        public HashSet<Private> Privates { get; }

        public void AddPrivates(HashSet<Private> privatesIds, string[] privateIds);
    }
}
