using NUnit.Framework;

namespace Skeleton.Test
{
    [TestFixture]
    public class AxeTest
    {
        private Dummy target;
        private Axe axe;
        private const int DURABILITY = 2;
        private const int ATTACK_POINTS = 2;
        private const int HEALTH = 10;
        private const int EXPERIENCE = 10;
        private const int EXPECTED_DURABILITY = 1;

        [SetUp]
        public void InitializeDummyAndAxe()
        {
            this.target = new Dummy(HEALTH, EXPERIENCE);
            this.axe = new Axe(ATTACK_POINTS, DURABILITY);
        }

        [Test]
        public void TestAxeDurability()  // AAA => Arrange.    // => Tripple AAA Pathern.
        {
            this.axe.Attack(this.target);         // AAA => Act.
            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(EXPECTED_DURABILITY), "Axe durability as not changing.");    // AAA => Assert. 
        }

        [Test]
        public void AttackWithBrokenWeapon() // AAA => Arrange.
        {
            this.axe.Attack(target);
            this.axe.Attack(target);
            Assert.That(() => this.axe.Attack(this.target),   // () => delegat is this case.  // AAA => Act.  // AAA => Assert.
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."), "Axe should be broken");
        }
    }
}
