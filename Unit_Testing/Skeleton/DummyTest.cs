using System;
using NUnit.Framework;

namespace Skeleton.Test

{   [TestFixture]
    public class DummyTest
    {
        private Dummy dummy; 
        private const int ATTACK_POINTS = 5;
        private const int HEALTH = 10;
        private const int EXPERIENCE = 5;
        private const int EXPECTED_HEALTH = 5;
        private const int EXPECTED_EXPERIENCE = 5;

        [SetUp]
        public void InitializeDummy()
        {
            this.dummy = new Dummy(HEALTH, EXPERIENCE);
        }

        [Test]
        public void TestDummyHealthLossesTakeAttack()
        {
            this.dummy.TakeAttack(ATTACK_POINTS);
            Assert.That(dummy.Health, Is.EqualTo(EXPECTED_HEALTH), "Dummy should loose health");
        }


        [Test]
        public void TestDeadDummyThrowExeptionIfAttacked()
        {
            this.dummy.TakeAttack(ATTACK_POINTS);
            this.dummy.TakeAttack(ATTACK_POINTS);
            Assert.That(() => dummy.TakeAttack(ATTACK_POINTS)  // () => delegat is this case.
            , Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), "Dummy should throw exeption");
        }

        [Test]
        public void TestDeadDummyCanGiveXP()
        {
            this.dummy.TakeAttack(ATTACK_POINTS);
            this.dummy.TakeAttack(ATTACK_POINTS);
            int expirience = dummy.GiveExperience();
            Assert.That(expirience, Is.EqualTo(EXPECTED_EXPERIENCE));
        }

        [Test]
        public void TestDeadDummyCanNotGiveXP()
        {
            Assert.That(() => this.dummy.GiveExperience(), 
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."), "Dummy should not give experience");
        }
    }
}
