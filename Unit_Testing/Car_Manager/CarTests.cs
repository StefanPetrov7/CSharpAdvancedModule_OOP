using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture()]
    public class CarTests
    {
        private CarManager.Car car;
        private const string MAKE = "testMake";
        private const string MODEL = "testModel";
        private const double F_CONSUMPTION = 1.0;
        private const double F_CAPACITY = 1.0;

        [SetUp]
        public void Setup()
        {
            car = new CarManager.Car(MAKE, MODEL, F_CONSUMPTION, F_CAPACITY);
        }

        [Test] // private ctor.
        public void IsCtorWorkingProperly()
        {
            Assert.IsNotNull(this.car);
        }


        [Test] // test ctor. { get ; set ;}
        public void TestIsParametersAreSetProperly()
        {
            Assert.AreEqual(MAKE, this.car.Make);
            Assert.AreEqual(MODEL, this.car.Model);
            Assert.AreEqual(F_CONSUMPTION, this.car.FuelConsumption);
            Assert.AreEqual(F_CAPACITY, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]  // test ctor.
        [TestCase("")]
        [TestCase(null)]
        public void MakeCannotBeNullOrEmpty(string make_test)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(make_test, MODEL, F_CONSUMPTION, F_CAPACITY));
        }

        [Test]  // test ctor.
        [TestCase("")]
        [TestCase(null)]
        public void ModeCannotBeNullOrEmpty(string model_test)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(MAKE, model_test, F_CONSUMPTION, F_CAPACITY));
        }

        [Test]  // test ctor.
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionCannotBeNegativeOrZero(double f_consumption_test)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(MAKE, MODEL, f_consumption_test, F_CAPACITY));
        }

        [Test]  // test ctor.
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityCannotBeZeroOrNegative(double f_capacity_test)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(MAKE, MODEL, F_CONSUMPTION, f_capacity_test));
        }

        [Test] // Refuel Method
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelAmountCannotBeZeroOrNegative(double ref_amount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(ref_amount));
        }

        [Test] // Refuel Method
        public void RefuelIsCorrectAmount()
        {
            double ref_amount = 1.0;
            double expected = ref_amount;
            car.Refuel(ref_amount);
            Assert.AreEqual(expected, car.FuelAmount);
        }

        [Test] // Refuel Method
        public void RefuelOverCapacity()
        {
            double ref_amount = 2.0;
            double expected = F_CAPACITY;
            car.Refuel(ref_amount);
            Assert.AreEqual(expected, car.FuelAmount);
        }

        [Test] // Drive Method
        public void FuelLeftAfterDriveDistance()
        {
            double expected = 0.99;
            car.Refuel(1);
            car.Drive(1);
            Assert.AreEqual(expected, car.FuelAmount);
        }

        [Test] // Drive Method
        public void NotEnoughFuel()
        {
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() => car.Drive(101));
        }

        [Test] // Drive Method
        public void CorrectAmountLeftAfterDrive()
        {
            double expected = 0;
            car.Refuel(1);
            car.Drive(100);
            Assert.AreEqual(expected, car.FuelAmount);
        }
    }
}