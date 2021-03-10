using System;
using NUnit.Framework;

namespace Bank_Account
{
    [TestFixture]  // => We are going to write our UNit test's in this class.
    public class BankAccountTest
    {
        private BankAccount bankAccount;

        [SetUp] // => this attribute will call the method before each test.
        public void Initialize()
        {
            this.bankAccount = new BankAccount(5000M); 
        }

        [Test]
        public void AccountInitializeWithPossitiveValue()
        {
            Assert.That(this.bankAccount.Amount, Is.EqualTo(5000M));
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            bankAccount.Deposit(1000);
            Assert.That(this.bankAccount.Amount, Is.EqualTo(6000M));
        }
    }
}
