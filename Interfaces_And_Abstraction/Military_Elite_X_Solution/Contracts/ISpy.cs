using System;
namespace Military_Elite.Contracts
{
    public interface ISpy: ISoldier
    {
        public string CodeNumber { get; }
    }
}
