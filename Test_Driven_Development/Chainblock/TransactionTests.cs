using NUnit.Framework;

using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;


namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {

        [Test]
        public void TestIfConstructorWorkesCorrectly()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(ts, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestWithInvalidId(int id)
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }
            , Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalideIdMessage));

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestWithInvalideId(string from)
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string to = "Gosho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }
            , Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalideSenderUserNameMEssage));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestWithInvalideReceiverName(string to)
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }
            , Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalideReceiverUserNameMEssage));
        }

        [Test]
        [TestCase(-1.0)]
        [TestCase(-0.000001)]
        [TestCase(0.0)]
        public void TestWithInvaldAmount(double amount)
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }
            , Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalideAmountMessage));
        }
    }
}
