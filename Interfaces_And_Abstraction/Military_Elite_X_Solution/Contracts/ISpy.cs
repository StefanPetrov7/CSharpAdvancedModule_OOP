using System;
namespace Military_Elite.Contracts
{
    public interface ISpy: ISoldier
    {
        public int CodeNumber { get; }
    }
}
