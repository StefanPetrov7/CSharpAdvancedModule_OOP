using System;
namespace Skeleton.Contracts
{
    public interface IWeapon
    {
        public int AttackPoints { get; }

        public int DurabilityPoints { get; }

        void Attack(ITarget target);

    }
}
