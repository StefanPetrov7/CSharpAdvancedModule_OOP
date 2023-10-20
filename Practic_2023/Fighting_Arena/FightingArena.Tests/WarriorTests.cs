namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {

        private Warrior testWarrior;

        [TestCase("")]
        [TestCase(null)]
        public void Test_Ctor_Name(string name)
        {
            Assert.Throws<ArgumentException>(() => this.testWarrior = new Warrior(name, 100, 100));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Test_Ctor_Damage(int damage)
        {
            Assert.Throws<ArgumentException>(() => this.testWarrior = new Warrior("Test", damage, 100));
        }

        [TestCase(-10)]
        public void Test_Ctor_Hp(int hp)
        {
            Assert.Throws<ArgumentException>(() => this.testWarrior = new Warrior("Test", 100, hp));
        }

        [TestCase("Test", 10, 10)]
        [TestCase("Test1", 1, 0)]
        public void Test_Ctor_Success_Created(string name, int damage, int hp)
        {
            this.testWarrior = new Warrior(name, damage, hp);
            Assert.That(testWarrior.Name, Is.EqualTo(name));
            Assert.That(testWarrior.Damage, Is.EqualTo(damage));
            Assert.That(testWarrior.HP, Is.EqualTo(hp));
        }

        [Test]
        public void Test_Attack_LowHP()
        {
            this.testWarrior = new Warrior("Test", 100, 15);
            Warrior attackedWarrior = new Warrior("Test1", 100, 100);

            Assert.That(() =>
            {
                this.testWarrior.Attack(attackedWarrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Test_Attack_Enemy_Low_HP()
        {
            this.testWarrior = new Warrior("Test", 100, 100);
            Warrior attackedWarrior = new Warrior("Test1", 100, 15);

            Assert.That(() =>
            {
                this.testWarrior.Attack(attackedWarrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void Test_Attack_With_LowerHP_Than_Attacker_Damage()
        {
            this.testWarrior = new Warrior("Test", 100, 50);
            Warrior attackedWarrior = new Warrior("Test1", 100, 100);

            Assert.That(() =>
            {
                this.testWarrior.Attack(attackedWarrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        [TestCase(100)]
        [TestCase(150)]
        public void Test_Successful_Attack_With_Highier_Damage(int damage)
        {
            this.testWarrior = new Warrior("Test", damage, 100);
            Warrior attackedWarrior = new Warrior("Test1", 100, 100);
            this.testWarrior.Attack(attackedWarrior);
            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void Test_Successful_Attack()
        {
            this.testWarrior = new Warrior("Test", 50, 100);
            Warrior attackedWarrior = new Warrior("Test1", 100, 50);
            this.testWarrior.Attack(attackedWarrior);
            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }
    }
}