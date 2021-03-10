using System;
using NUnit.Framework;

namespace Skeleton.Test
{
    [TestFixture]
    public class AxeTest
    {
        private Dummy target;

        [SetUp]
        public void InitializeDummy()
        {
            this.target = new Dummy(10, 10);
        }

        [Test]
        public void TestAxeDurability()  // AAA => Arrange.    // => Tripple AAA Pathern.
        {
            Axe axe = new Axe(2, 2);
            axe.Attack(this.target);         // AAA => Act.
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe durability as not changing.");    // AAA => Assert. 
        }
         
        [Test]
        public void AttackWithBrokenWeapon() // AAA => Arrange.
        {
            Axe axe = new Axe(2, 0);
            Assert.That(() => axe.Attack(this.target),   // () => delegat is this case.  // AAA => Act.  // AAA => Assert.
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));

        }
    }
}
