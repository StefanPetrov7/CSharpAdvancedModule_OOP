using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item itemOne;
        private Item itemTwo;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.itemOne = new Item("Test", "1234");
            this.itemTwo = new Item("Test2", "5678");
            this.bankVault = new BankVault();
        }

        [Test]
        public void TestItemCtor()
        {
            Assert.IsNotNull(this.itemOne);
        }

        [Test]
        public void TestItemOwnerAndIdAreCorrect()
        {
            Assert.AreEqual(this.itemOne.Owner, "Test");
            Assert.AreEqual(this.itemOne.ItemId, "1234");
        }

        [Test]
        public void TestBankValultCtor()
        {
            Assert.IsNotNull(this.bankVault);
        }

        [Test]
        public void TestAddItemThrowError()
        {
            Assert.That(() =>
            {
                this.bankVault.AddItem("C5", this.itemOne);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));

            Assert.That(() =>
            {
                this.bankVault.AddItem("C4", this.itemOne);
                this.bankVault.AddItem("C4", this.itemTwo);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));

            Assert.That(() =>
            {
                this.bankVault.AddItem("C1", this.itemOne);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void TestAddingItemSuccessfully()
        {
            string message = this.bankVault.AddItem("C4", this.itemOne);
            Assert.AreEqual(message, $"Item:{this.itemOne.ItemId} saved successfully!");
        }

        [Test]
        public void TestRemovingItemThrowsError()
        {
            Assert.That(() =>
            {
                this.bankVault.RemoveItem("C5", this.itemOne);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));

            Assert.That(() =>
            {
                this.bankVault.AddItem("C4", this.itemOne);
                this.bankVault.RemoveItem("C4", this.itemTwo);
            }, Throws.ArgumentException.With.Message.EqualTo($"Item in that cell doesn't exists!"));
        }

        [Test]
        public void TestRemovingItemSuccessfully()
        {
            this.bankVault.AddItem("C4", this.itemOne);
            this.bankVault.AddItem("C3", this.itemTwo);
            string message = this.bankVault.RemoveItem("C4", this.itemOne);
            Assert.AreEqual(message, $"Remove item:{this.itemOne.ItemId} successfully!");
        }
    }
}