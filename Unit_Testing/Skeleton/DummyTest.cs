using System;
using NUnit.Framework;

namespace Skeleton.Test

{   [TestFixture]
    public class DummyTest
    {
        //private Hero hero;  // We don't use Hero in the test's in order to BUGS and ERRORS from other class.

        //[SetUp]
        //public void InitializeDummy()
        //{
        //    this.hero = new Hero("Stefan");
        //}

        [Test]
        public void TestDummyHealthLossesTakeAttack()
        {
            Dummy dummy = new Dummy(20, 20);
            dummy.TakeAttack(10);
            Assert.That(dummy.Health, Is.EqualTo(10));
        }

        //[Test]
        //public void TestDummyHealthLossesAttacked()
        //{
        //    Dummy dummy = new Dummy(20, 20);
        //    hero.Attack(dummy);
        //    Assert.That(dummy.Health, Is.EqualTo(10));
        //}

        [Test]
        public void TestDeadDummyThrowExeptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 0);
            Assert.That(() => dummy.TakeAttack(10)  // () => delegat is this case.
            , Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void TestDeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 5);
            int expirience = dummy.GiveExperience();
            Assert.That(expirience, Is.EqualTo(5));
        }

        [Test]
        public void TestDeadDummyCanNotGiveXP()
        {
            Dummy dummy = new Dummy(5, 5);
            Assert.That(() => dummy.GiveExperience(), 
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
