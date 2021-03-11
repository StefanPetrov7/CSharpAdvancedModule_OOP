using System;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Skeleton.Test
{
    [TestFixture]
    public class HeroTest
    {
        //private IWeapon weapon; // My Test.
        //private ITarget dummy;
        //private Hero hero;
        //private const string NAME = "Stefan";
        //private const int DURABILITY = 10;
        //private const int ATTACK_POINTS = 10;
        //private const int HEALTH = 5;
        //private const int EXPERIENCE = 5;

        //[SetUp]
        //public void InitializeHeroAndTarget()
        //{
        //    //this.weapon = new Axe(ATTACK_POINTS, DURABILITY); // My Test.
        //    //this.hero = new Hero(NAME, weapon);
        //    //this.dummy = new Dummy(HEALTH, EXPERIENCE);

        //}

        //[Test]
        //public void TestHeroGainsXPWhenTargetDies()  // My Test.
        //{
        //    this.hero.Attack(this.dummy);
        //    Assert.That(hero.Experience, Is.EqualTo(EXPERIENCE), "Hero is not gaining XP");
        //}

        [Test]
        public void TestHeroGainsXPWhenTargetDies()
        {
            IWeapon weapon = new FakeWeapon();
            ITarget target = new FakeTarget();
            Hero hero = new Hero("Pesho", weapon);  // Stamo Test.

            hero.Attack(target);
            Assert.That(hero.Experience, Is.EqualTo(10), "Hero is not gaining XP");
        }


    }
}
