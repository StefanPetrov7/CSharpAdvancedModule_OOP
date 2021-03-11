using System;
using Skeleton.Contracts;

namespace Skeleton.Test
{
    public class FakeTarget : ITarget
    {

        public int Health => 0;

        public int GiveExperience()
        {
            return 10;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints) { }  // => Not needed at the moment. 
   
    }
}
