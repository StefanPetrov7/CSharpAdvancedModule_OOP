namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;

        [SetUp]
        public void Setup()
        {
            this.device = new Device(10);
        }

        [Test]
        public void TestCtor()
        {
            Assert.IsNotNull(this.device);
            Assert.That(this.device.MemoryCapacity, Is.EqualTo(10));
            Assert.That(this.device.MemoryCapacity, Is.EqualTo(10));
            Assert.That(this.device.Photos, Is.EqualTo(0));
            Assert.IsNotNull(this.device.Applications);
        }

        [Test]
        public void TestTakePhotos()
        {
            Assert.That(this.device.TakePhoto(5), Is.True);
            Assert.That(this.device.AvailableMemory, Is.EqualTo(5));
            Assert.That(this.device.Photos, Is.EqualTo(1));
        }

        [Test]
        public void TestTakePhotosNotWorking()
        {
            Assert.That(this.device.TakePhoto(11), Is.False);
        }

        [Test]
        public void TestInstalApplicationNotWorking()
        {
            string appName = "test";
            int appSize = 11;

            Assert.That(() =>
            {
                this.device.InstallApp(appName, appSize);
            }, Throws.InvalidOperationException.With.Message.EqualTo($"Not enough available memory to install the app."));
        }

        [Test]
        public void TestInstalApplicationWorking()
        {
            string appName = "test";
            int appSize = 5;
            string message = $"{appName} is installed successfully. Run application?";
            Assert.That(this.device.InstallApp(appName, appSize), Is.EquivalentTo(message));
            Assert.That(this.device.AvailableMemory, Is.EqualTo(5));
        }

        [Test]
        public void TestFormatDevice()
        {
            string appName = "test";
            int appSize = 5;
            this.device.InstallApp(appName, appSize);
            this.device.FormatDevice();
            Assert.That(this.device.Photos, Is.EqualTo(0));
            Assert.That(this.device.AvailableMemory, Is.EqualTo(this.device.MemoryCapacity));
        }

        [Test]
        public void TestGetDeviceStatusReturnCorrectString()
        {
            this.device.TakePhoto(2);
            this.device.InstallApp("Test", 2);
            string result = this.device.GetDeviceStatus();
            Assert.That(this.device.GetDeviceStatus(), Is.EqualTo(result));
        }

        [Test]
        public void TestGetDeviceStatusReturnWrongString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Memory Capacity: {this.device.MemoryCapacity} MB, Available Memory: {this.device.AvailableMemory} MB");
            stringBuilder.AppendLine($"Photos Count: {this.device.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", this.device.Applications)}");
            string result = stringBuilder.ToString().TrimEnd();
            this.device.TakePhoto(2);
            this.device.InstallApp("Test", 2);
            Assert.That(this.device.GetDeviceStatus(), Is.Not.EqualTo(result));
        }
    }
}