namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warriorOne;
        private Warrior WarriorTwo;
        private Warrior WarriorThree;


        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
            this.warriorOne = new Warrior("One", 100, 100);
            this.WarriorTwo = new Warrior("Two", 150, 150);
            this.WarriorThree = new Warrior("Three", 200, 200);
        }

        [Test]
        public void Test_Arena_Ctor()
        {
            Assert.That(this.arena, Is.Not.Null);
        }

        [Test]
        public void Test_Arena_Ctor_Count()
        {
            this.arena.Enroll(this.warriorOne);
            this.arena.Enroll(this.WarriorTwo);
            Assert.That(this.arena.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_Arena_Enroll_Warriors_Throws_Exception_ForSameNames()
        {
            Warrior sameName = new Warrior("Test", 50, 50);
            this.arena.Enroll(sameName);
            this.arena.Enroll(this.warriorOne);
            Assert.That(() =>
            {
                this.arena.Enroll(sameName);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        [TestCase("MissingName")]
        public void Test_Arena_Warriors_Fight_Missing_Deffender_Missing_Attacker(string missingWarrior)
        {
            this.arena.Enroll(this.warriorOne);
            this.arena.Enroll(this.WarriorTwo);
            this.arena.Enroll(this.WarriorThree);

            Assert.That(() =>
            {
                this.arena.Fight(this.warriorOne.Name, missingWarrior);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {missingWarrior} enrolled for the fights!"));

            Assert.That(() =>
            {
                this.arena.Fight(missingWarrior, this.WarriorTwo.Name);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {missingWarrior} enrolled for the fights!"));
        }

        [Test]
        public void Test_Successful_Fight_With_Valid_Warriors()
        {
            this.arena.Enroll(this.warriorOne);
            this.arena.Enroll(this.WarriorTwo);
            this.arena.Enroll(this.WarriorThree);
            this.arena.Fight(this.WarriorTwo.Name, this.warriorOne.Name);
            Assert.That(this.warriorOne.HP, Is.EqualTo(0));
        }

        [Test]
        public void Test_Not_Successful_Fight_Due_ToWeakAttacker()
        {
            this.arena.Enroll(this.warriorOne);
            this.arena.Enroll(this.WarriorTwo);
            this.arena.Enroll(this.WarriorThree);
            Assert.That(() =>
            {
                this.arena.Fight(this.warriorOne.Name, this.WarriorTwo.Name);
            },Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }
    }
}
