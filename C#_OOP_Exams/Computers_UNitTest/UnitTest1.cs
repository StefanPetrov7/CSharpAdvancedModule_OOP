using System;
using System.Collections.Generic;
using Computers_UNitTest;
using NUnit.Framework;

namespace Computer_UNitTest
{
    [TestFixture]
    public class Tests
    {
        private Computer computer;
        private ComputerManager computers;

        [SetUp]
        public void SetUp()
        {
            this.computer = new Computer("TestIntel", "TestPentium", 200);
            this.computers = new ComputerManager();
        }

        [Test]
        public void TestCtor()
        {
            Assert.IsNotNull(this.computer);
            Assert.AreEqual("TestIntel", this.computer.Manufacturer);
            Assert.AreEqual("TestPentium", this.computer.Model);
            Assert.AreEqual(200, this.computer.Price);
        }

        [Test]
        public void TestCtorManager()
        {
            Assert.AreEqual(0, this.computers.Count);
            Assert.IsNotNull(this.computers);
        }

        [Test]
        public void AddNullThrowsException()
        {
            Assert.Throws<ArgumentException>(()=> this.computers.AddComuter(null));
        }

        [Test]
        public void TestAddComputer()
        {
            this.computers.AddComuter(this.computer);
            Assert.AreEqual(1, this.computers.Count);
        }

        [Test]
        public void TestAddSameComputer()
        {
            Computer computerOne = new Computer("Same", "Same", 100);
            Computer computerSame = new Computer("Same", "Same", 100);
            Computer computerTwo = new Computer("Different", "Fifferent", 100);
            this.computers.AddComuter(computerOne);
            this.computers.AddComuter(computerTwo);
            Assert.Throws<ArgumentException>(() => this.computers.AddComuter(computerSame));
        }

        [Test]
        public void TestGetComputerByManufacturer()
        {
            Computer computerOne = new Computer("One", "Test", 100);
            Computer computerTwo = new Computer("Same", "Test1", 100);
            Computer computerThree = new Computer("Same", "Test2", 100);
            Computer computerFour = new Computer("Same", "Test3", 100);
            this.computers.AddComuter(computerOne);
            this.computers.AddComuter(computerTwo);
            this.computers.AddComuter(computerThree);
            this.computers.AddComuter(computerFour);
            ICollection<Computer> testCollection = this.computers.GetComputerByManufacturer("Same");
            Assert.AreEqual(3, testCollection.Count);
        }

        [Test]
        public void GetComputer()
        {
            Computer computerOne = new Computer("One", "Test", 100);
            Computer computerTwo = new Computer("Same", "Test1", 100);
            Computer computerThree = new Computer("Same", "Test2", 100);
            Computer computerFour = new Computer("Same", "Test3", 100);

            this.computers.AddComuter(computerOne);
            this.computers.AddComuter(computerTwo);
            this.computers.AddComuter(computerThree);
            this.computers.AddComuter(computerFour);

            Computer receivedOne = this.computers.GetComputer("One", "Test");
            Assert.AreEqual(receivedOne, computerOne);
        }

        [Test]
        public void GetComputerReturnNullAndException()
        {
            Computer computerOne = new Computer("One", "Test", 100);
            Computer computerTwo = new Computer("Same", "Test1", 100);
            Computer computerThree = new Computer("Same", "Test2", 100);
            Computer computerFour = new Computer("Same", "Test3", 100);

            this.computers.AddComuter(computerOne);
            this.computers.AddComuter(computerTwo);
            this.computers.AddComuter(computerThree);
            this.computers.AddComuter(computerFour);

            Assert.Throws<ArgumentException>(()=> this.computers.GetComputer("NoExist", "Test"));
        }

        [Test]
        public void RemoveComputerGivesCorrectCount()
        {
            Computer computerOne = new Computer("One", "Test", 100);
            Computer computerTwo = new Computer("Same", "Test1", 100);
            Computer computerThree = new Computer("Same", "Test2", 100);
            Computer computerFour = new Computer("Same", "Test3", 100);

            this.computers.AddComuter(computerOne);
            this.computers.AddComuter(computerTwo);
            this.computers.AddComuter(computerThree);
            this.computers.AddComuter(computerFour);

            Computer receivedOne = this.computers.GetComputer("One", "Test");
            Assert.AreEqual(3, this.computers.Count);
        }
    }
}