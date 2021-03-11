using System;
using Skeleton.Contracts;

namespace Skeleton.Test
{
    public class FakeWeapon : IWeapon
    {

        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(ITarget target) { } // Not needed at the moment.

    }
}
