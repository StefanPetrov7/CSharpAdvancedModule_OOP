using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] overCapacity;
        private ExtendedDatabase.ExtendedDatabase exDatabase;

        [SetUp]
        public void InitializePerso()
        {
            overCapacity = new Person[17];
            this.exDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]    // Test Ctor.
        public void CreatedWithOverCapacity()
        {
            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(overCapacity),
                Throws.ArgumentException);
        }

        [Test] // Test Ctor.
        public void CreatedEmtyDatabase()
        {
            int expected = 1;
            this.exDatabase = new ExtendedDatabase.ExtendedDatabase(new Person(1, "A"));
            Assert.AreEqual(expected, this.exDatabase.Count);
        }

        [Test] // Test Ctor.
        public void CtorAddCorrectUserId()
        {
            Person[] test = new Person[]
            {
                 new Person(1, "x"),
                 new Person(1, "y")
            };

            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(test), Throws.InvalidOperationException);
        }

        [Test] // Test Ctor.
        public void CtorAddCorrectUserName()
        {
            Person[] test = new Person[]
            {
                 new Person(1, "x"),
                 new Person(2, "x")
            };

            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(test), Throws.InvalidOperationException);
        }

        [Test]
        public void AddUsserWithSameName()
        {
            Person personX = new Person(1, "x");
            Person personY = new Person(2, "x");
            this.exDatabase.Add(personX);
            Assert.Throws<InvalidOperationException>(() => this.exDatabase.Add(personY));
        }

        [Test]
        public void AddUsserWithSameId()
        {
            Person personX = new Person(1, "x");
            Person personY = new Person(1, "y");
            this.exDatabase.Add(personX);
            Assert.Throws<InvalidOperationException>(() => this.exDatabase.Add(personY));
        }

        [Test]
        public void AddDataOverTheCapacity()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }
            this.exDatabase = new ExtendedDatabase.ExtendedDatabase(persons);
            Person extraPerson = new Person(17, "x");
            Assert.That(() => this.exDatabase.Add(extraPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethosShowsCorrectCount()
        {
            int expectedCount = 1;
            Person personX = new Person(1, "x");
            this.exDatabase.Add(personX);
            Assert.AreEqual(expectedCount, exDatabase.Count);
        }

        [Test]
        public void RemoveIfArrayIsEmpty()
        {
            Assert.That(() => this.exDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethodShowsCorrectCountAfterRemoving()
        {
            int expectedCount = 0;
            Person personX = new Person(1, "x");
            this.exDatabase.Add(personX);
            this.exDatabase.Remove();
            Assert.AreEqual(expectedCount, exDatabase.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void IsNameNullOrEmptyString(string name)
        {
            Person personX = new Person(1, "x");
            this.exDatabase.Add(personX);
            Assert.That(() => this.exDatabase.FindByUsername(name), Throws.ArgumentNullException);
        }

        [Test]
        public void SearchedNameDontExist()
        {
            Person personX = new Person(1, "x");
            string name = "Test";
            this.exDatabase.Add(personX);
            Assert.That(() => this.exDatabase.FindByUsername(name), Throws.InvalidOperationException);
        }

        [Test]
        public void SearchedIfNameIsValid()
        {
            Person personX = new Person(1, "x");
            string name = "x";
            this.exDatabase.Add(personX);
            Person expectedPerson = exDatabase.FindByUsername(name);
            Assert.AreEqual(expectedPerson, personX);
        }

        [Test]
        public void IsIdNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.exDatabase.FindById(-1));
        }

        [Test]
        public void IdDoesntExist()
        {
            Person personX = new Person(1, "x");
            this.exDatabase.Add(personX);
            Assert.That(() => this.exDatabase.FindById(2), Throws.InvalidOperationException);
        }

        [Test]
        public void IdExist()
        {
            Person personX = new Person(1, "x");
            this.exDatabase.Add(personX);
            Person expectedPerson = this.exDatabase.FindById(1);
            Assert.AreEqual(expectedPerson, personX);
        }
    }
}