using System;
using NUnit.Framework;

namespace FightingArena
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private const string NAME = "Test";
        private const int DAMAGE = 10;
        private const int HP = 50;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(NAME, DAMAGE, HP);
        }

        [Test] // Test Ctor.
        [TestCase(null, DAMAGE, HP)]
        [TestCase("", DAMAGE, HP)]
        [TestCase(" ", DAMAGE, HP)]
        [TestCase(NAME, -1, HP)]
        [TestCase(NAME, 0, HP)]
        [TestCase(NAME, DAMAGE, -1)]
        public void CtorInitializeTest(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test] // Ctor
        public void IsCtorPArametersAreCorrect()
        {
            Assert.AreEqual(NAME, this.warrior.Name);
            Assert.AreEqual(DAMAGE, this.warrior.Damage);
            Assert.AreEqual(HP, this.warrior.HP);
        }

        [Test] // Attack Method
        public void CannotAttackIfHpBeloqOrEqualThirty()
        {
            this.warrior = new Warrior(NAME, 50, 30);
            Warrior attacked = new Warrior("Attacked", 30, 50);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(attacked));
        }

        [Test] // Attack Method
        public void CannotAttackWarriosWithLessHpThan30()
        {
            this.warrior = new Warrior(NAME, 50, 31);
            Warrior attacked = new Warrior("Attacked", 30, 30);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(attacked));
        }

        [Test] // Attack Method
        public void CannotAttackStrongerEnemies()
        {
            this.warrior = new Warrior(NAME, 50, 35);
            Warrior attacked = new Warrior("Attacked", 50, 35);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(attacked));
        }

        [Test]
        public void AttackerHpNeedToBeReducedAfterAttack()
        {
            int expected = 10;
            this.warrior = new Warrior(NAME, 50, 60);
            Warrior attacked = new Warrior("Attacked", 50, 50);
            this.warrior.Attack(attacked);
            Assert.AreEqual(expected, this.warrior.HP);
        }

        [Test]
        public void AttackedHpNeedToBeZero()
        {
            int expected = 0;
            this.warrior = new Warrior(NAME, 51, 60);
            Warrior attacked = new Warrior("Attacked", 50, 50);
            this.warrior.Attack(attacked);
            Assert.AreEqual(expected, attacked.HP);
        }


        [Test]
        public void AttackedHpNeedToBeReduced()
        {
            int expected = 1;
            this.warrior = new Warrior(NAME, 49, 60);
            Warrior attacked = new Warrior("Attacked", 50, 50);
            this.warrior.Attack(attacked);
            Assert.AreEqual(expected, attacked.HP);
        }

    }
}