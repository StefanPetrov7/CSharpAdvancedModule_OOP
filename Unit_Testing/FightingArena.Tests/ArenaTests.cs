using System;
using FightingArena;
using NUnit.Framework;

namespace FightingArena
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private const string NAME = "Test";
        private const int DAMAGE = 10;
        private const int HP = 50;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior(NAME, DAMAGE, HP);
        }

        [Test] // Ctor
        public void ArenaNeedToBeInitialized()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test] // Ctor
        public void CountNeedToBeZeroAsPerDefault()
        {
            int expected = 0;
            Assert.AreEqual(expected, this.arena.Count);
        }

        [Test] // Enrroll Method
        public void WarriorNeedToBeEnrolled()
        {
            int expected = 1;
            this.arena.Enroll(this.warrior);
            Assert.AreEqual(expected, this.arena.Count);
        }

        [Test] // Enrroll Method
        public void TestIfSameWarriorCanBeEnrolledAgain()
        {
            this.arena.Enroll(this.warrior);
            Warrior sameName = new Warrior(NAME, 50, 50);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(sameName));
        }

        [Test] // Fight Method
        public void TestIfDefenderIsNotEnrolled()
        {
            string defender = "defender";
            this.arena.Enroll(this.warrior);
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(NAME,defender));
        }

        [Test] // Fight Method
        public void TestIfAttackerIsNotEnrolled()
        {
            string attacker = "Attacker";
            this.arena.Enroll(this.warrior);
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker, NAME));
        }

        [Test] // Fight Method
        public void TestIfFightIsEnroled()
        {
            int expected = 1;
            Warrior attacker= new Warrior("attacker", 49, 60);
            Warrior defender = new Warrior("defender", 50, 50);
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);
            this.arena.Fight(attacker.Name, defender.Name);
            Assert.AreEqual(expected, defender.HP);
        }
    }
}
