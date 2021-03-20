using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private UnitDriver unitDriver;
        private UnitCar unitCar;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.unitCar = new UnitCar("car", 10, 10);
            this.unitDriver = new UnitDriver("driver", this.unitCar);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void TestCarCtor()
        {
            Assert.AreEqual("car", this.unitCar.Model);
            Assert.AreEqual(10, this.unitCar.HorsePower);
            Assert.AreEqual(10, this.unitCar.CubicCentimeters);
        }

        [Test]
        public void TestDriverCtor()
        {
            Assert.AreEqual("driver", this.unitDriver.Name);
            Assert.AreEqual("car", this.unitDriver.Car.Model);
            Assert.AreEqual(10, this.unitDriver.Car.HorsePower);
            Assert.AreEqual(10, this.unitDriver.Car.CubicCentimeters);
        }

        [Test]
        public void TestDriverCtorException()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, this.unitCar));
        }

        [Test]
        public void TestRaceEntryCtor()
        {
            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void TestAddNullDriver()
        {
            this.unitDriver = null;
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(this.unitDriver));
        }

        [Test]
        public void TestAddSameDriver()
        {
            UnitDriver test = new UnitDriver("driver", new UnitCar("CarTest", 10, 10));
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddDriver(this.unitDriver);
                this.raceEntry.AddDriver(test);
            });
        }

        [Test]
        public void TestAddDriverSuccessfully()
        {
            UnitDriver test = new UnitDriver("driverTest", new UnitCar("CarTest", 10, 10));
            this.raceEntry.AddDriver(this.unitDriver);
            this.raceEntry.AddDriver(test);
            Assert.AreEqual(2, this.raceEntry.Counter);
        }

        [Test]
        public void TestCalculateAvgException()
        {
            this.raceEntry.AddDriver(this.unitDriver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCorrectAvgCalculation()
        {
            UnitDriver test = new UnitDriver("driverTest", new UnitCar("CarTest", 10, 10));
            this.raceEntry.AddDriver(this.unitDriver);
            this.raceEntry.AddDriver(test);
            Assert.AreEqual(10, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}