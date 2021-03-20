using System;
using NUnit.Framework;

namespace Robots.Tests
{
    [TestFixture]
    public class Tests
    {
        private int capacity = 2;
        private string name = "Tesla";
        private string nameTwo = "TeslaTwo";
        private int battery = 10;
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            this.robot = new Robot(name, battery);
            this.robotManager = new RobotManager(capacity);
        }

        [Test] // Ctor Robot
        public void RobotCtorShouldReturnCorrectParameters()
        {
            Assert.AreEqual(name, this.robot.Name);
            Assert.AreEqual(battery, this.robot.Battery);
            Assert.AreEqual(battery, this.robot.MaximumBattery);
            Assert.IsNotNull(this.robot);
        }

        [Test] // Ctor RobotManager
        public void RobotManagerCtorShouldReturnCorrectParameters()
        {
            int expected = 0;
            Assert.AreEqual(expected, this.robotManager.Count);
            Assert.AreEqual(capacity, this.robotManager.Capacity);
            Assert.AreEqual(battery, this.robot.MaximumBattery);
            Assert.IsNotNull(this.robotManager);
        }

        [Test]
        public void CtorShoudThrowExceptionDueToNegativeCapacity()
        {
            int negativeCapacity = -2;
            Assert.Throws<ArgumentException>(() => new RobotManager(negativeCapacity));
        }

        [Test]
        public void RobotManagerShouldThrowSameNameExcetionWhenAdding()
        {
            Robot sameNameRobot = new Robot(name, 20);
            this.robotManager.AddRobots(this.robot);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.AddRobots(sameNameRobot));
        }


        [Test]
        public void RobotManagerShouldThrowSOverCapacityExcetionWhenAdding()
        {
            Robot robotTwo = new Robot(nameTwo, 20);
            Robot robotThree = new Robot("Test", 30);
            this.robotManager.AddRobots(this.robot);
            this.robotManager.AddRobots(robotTwo);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.AddRobots(robotThree));
        }

        [Test]
        public void RobotManagerShouldAddRobot()
        {
            int expected = 1;
            this.robotManager.AddRobots(this.robot);
            Assert.AreEqual(expected, this.robotManager.Count);
        }

        [Test]
        public void RobotManagerShouldThrowExceptionWhenRemovingNotExistingRobot()
        {
            string name = "Test";
            Robot robotTwo = new Robot(nameTwo, 20);
            this.robotManager.AddRobots(this.robot);
            this.robotManager.AddRobots(robotTwo);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove(name));
        }

        //[Test] // => throws null reference exception !!!!
        //public void RobotManagerShouldThrowExceptionWhenRemovingNullRobot()
        //{
        //    Robot noRobot = null;
        //    Robot robotTwo = new Robot(nameTwo, 20);
        //    this.robotManager.AddRobots(this.robot);
        //    this.robotManager.AddRobots(robotTwo);
        //    Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove(noRobot.Name));
        //}

        [Test]
        public void RobotMAnageShouldRemoveRobotCorrectly()
        {
            int expected = 1;
            Robot robotTwo = new Robot(nameTwo, 20);
            this.robotManager.AddRobots(this.robot);
            this.robotManager.AddRobots(robotTwo);
            this.robotManager.Remove(robotTwo.Name);
            Assert.AreEqual(expected, this.robotManager.Count);
        }


        [Test]
        public void RobotWorkShouldThrowExceptionDueToNotEnoughBattery()
        {
            this.robotManager.AddRobots(this.robot);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(this.robot.Name, "Work", 20));
        }

        [Test]
        public void RobotWorkShouldDischargeCorrectAmountOfBatteryUsage()
        {
            int expected = 1;
            this.robotManager.AddRobots(this.robot);
            this.robotManager.Work(this.robot.Name, "Work", 9);
            Assert.AreEqual(expected, this.robot.Battery);
        }

        [Test]
        public void RobotBatteryShouldChargeToMaxCapacity()
        {
            int expected = 10;
            this.robotManager.AddRobots(this.robot);
            this.robotManager.Work(this.robot.Name, "Work", 9);
            this.robotManager.Charge(this.robot.Name);
            Assert.AreEqual(expected, this.robot.Battery);
        }
    }
}