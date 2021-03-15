using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using Chainblock.Core;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainBlock;
        private ITransaction testF;
        private ITransaction testD;


        [SetUp]
        public void SetUp()
        {
            this.chainBlock = new Core.ChainBlock();   
            this.testF = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 10);
            this.testD = new Transaction(2, TransactionStatus.Successfull, "Ivan", "Ivanov", 20);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expected = 0;
            IChainblock chainBlock = new ChainBlock();
            Assert.AreEqual(expected, chainBlock.Count);
        }

        [Test]
        public void AddShouldIncreaseCountIfSuccess()
        {
            // Assert
            int expected = 1;
            ITransaction transactionTest = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", 2.0);

            // Act
            this.chainBlock.Add(transactionTest);

            // Assert
            Assert.AreEqual(expected, this.chainBlock.Count);

        }

        [Test]
        public void AddExistingTransactionShouldThrowException()
        {
            ITransaction transactionTest = new Transaction(2, TransactionStatus.Failed, "Ivan", "Stoyan", 2.0);
            this.chainBlock.Add(transactionTest);

            Assert.That(() =>
            {
                this.chainBlock.Add(transactionTest);
            }
            , Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.TransactionHasBeenAddedAlready));
        }

        [Test]
        public void AddingSameTransactionWithDifferentIdShouldPass()
        {
            int expected = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;
            ITransaction transactionOne = new Transaction(1, ts, from, to, amount);
            ITransaction transactionTwo = new Transaction(2, ts, from, to, amount);
            this.chainBlock.Add(transactionOne);
            this.chainBlock.Add(transactionTwo);
            Assert.AreEqual(expected, this.chainBlock.Count);
        }

        [Test]
        public void TestContainsReturnTrueByTransaction()
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;
            ITransaction transactionOne = new Transaction(1, ts, from, to, amount);
            ITransaction transactionTwo = new Transaction(2, ts, from, to, amount);
            this.chainBlock.Add(transactionOne);
            this.chainBlock.Add(transactionTwo);
            Assert.IsTrue(this.chainBlock.Contains(transactionTwo));
        }

        [Test]
        public void TestContainsReturnTrueByIdNumber()
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;
            ITransaction transactionOne = new Transaction(1, ts, from, to, amount);
            ITransaction transactionTwo = new Transaction(2, ts, from, to, amount);
            this.chainBlock.Add(transactionOne);
            this.chainBlock.Add(transactionTwo);
            Assert.IsTrue(this.chainBlock.Contains(2));
        }

        [Test]
        public void TestContainsReturnFalseByIdNumber()
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;
            ITransaction transactionOne = new Transaction(1, ts, from, to, amount);
            ITransaction transactionTwo = new Transaction(2, ts, from, to, amount);
            this.chainBlock.Add(transactionOne);
            this.chainBlock.Add(transactionTwo);
            Assert.IsFalse(this.chainBlock.Contains(3));
        }

        [Test]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull)]
        public void TransactionStatusShuoldChange(TransactionStatus status)
        {
            TransactionStatus ts = TransactionStatus.Unauthorized;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;
            ITransaction transactionOne = new Transaction(1, ts, from, to, amount);
            this.chainBlock.Add(transactionOne);
            this.chainBlock.ChangeTransactionStatus(1, status);
            Assert.AreEqual(status, transactionOne.Status);
        }

        [Test]
        public void NuSuchTransactionThenThrowException()
        {
            this.chainBlock.Add(this.testF);

            Assert.That(() =>
            {
                this.chainBlock.ChangeTransactionStatus(5, TransactionStatus.Unauthorized);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.NoSuchTransaction));
        }

        [Test]
        public void ReturnCorrectTransactionById()
        {
            int id = 1;
            this.chainBlock.Add(this.testF);
            this.chainBlock.Add(this.testD);
            Assert.AreEqual(id, this.chainBlock.GetById(1).Id);
        }

        [Test]
        public void ReturnTransactionByIdThrowExceptionNoSuchTransaction()
        {
            int id = 15;
            this.chainBlock.Add(this.testF);
            this.chainBlock.Add(this.testD);
            Assert.That(() =>
            {
                this.chainBlock.GetById(id);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.NoSuchTransaction));
        }

        [Test]
        public void TransactionShouldBeRemovedByIdAndCountShouldBeDecreased()
        {
            int expectedCount = 1;
            this.chainBlock.Add(this.testF);
            this.chainBlock.Add(this.testD);
            this.chainBlock.RemoveTransactionById(this.testF.Id);
            Assert.AreEqual(expectedCount, this.chainBlock.Count);
        }

        [Test]
        public void RemovedTransactionShouldBePhysicalyRemoved()
        {
            this.chainBlock.Add(this.testF);
            this.chainBlock.Add(this.testD);
            this.chainBlock.RemoveTransactionById(this.testF.Id);
            Assert.That(() =>
            {
                this.chainBlock.GetById(this.testF.Id);
            }
            , Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.NoSuchTransaction));
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowExceptionForNotSuchTransaction()
        {
            int id = 15;
            this.chainBlock.Add(this.testF);
            this.chainBlock.Add(this.testD);
            Assert.Throws<ArgumentException>(() => this.chainBlock.RemoveTransactionById(id));
        }

        [Test]
        public void ReturnTransactionsOrderedByStatusWithDecendingAmount()
        {
            ICollection<ITransaction> expectedTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)i;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);

                if (status == TransactionStatus.Successfull)
                {
                    expectedTr.Add(curTransaction);
                }

                this.chainBlock.Add(curTransaction);
            }

            ITransaction succesfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expectedTr.Add(succesfulTransaction);
            this.chainBlock.Add(succesfulTransaction);
            IEnumerable<ITransaction> actualTr = this.chainBlock.GetByTransactionStatus(TransactionStatus.Successfull);
            expectedTr = expectedTr.OrderByDescending(tr => tr.Amount).ToList();
            CollectionAssert.AreEqual(expectedTr, actualTr);
        }

        [Test]
        public void GettingTransactionsWithExistingStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Failed;
                string from = "Test" + i;
                string to = "To" + i;
                double amount = 10 * i + 1;
                ITransaction currentTransaction = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currentTransaction);
            }

            Assert.That(() =>
            {
                this.chainBlock.GetByTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionsWithGivenStatus));
        }

        [Test]
        public void TestAllSendTransactionWithGivenStatusToBeCorrect()
        {
            ICollection<ITransaction> expectedTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)i;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);

                if (status == TransactionStatus.Successfull)
                {
                    expectedTr.Add(curTransaction);
                }

                this.chainBlock.Add(curTransaction);
            }

            ITransaction succesfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expectedTr.Add(succesfulTransaction);
            this.chainBlock.Add(succesfulTransaction);
            IEnumerable<string> actualTr = this.chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expectedTrResult = expectedTr.OrderByDescending(tr => tr.Amount).Select(tr => tr.From);
            CollectionAssert.AreEqual(expectedTrResult, actualTr);
        }

        [Test]
        public void TestAllSendTransactionsWithGivenStatusToThrowException()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Failed;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 * i + 1;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(curTransaction);

                Assert.That(() =>
                {
                    this.chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
                }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionsWithGivenStatusFromThatSender));
            }

        }

        [Test]
        public void TestAllReceivedTransactionsWithGivenStatusToBeCorrect()
        {
            ICollection<ITransaction> expectedTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)i;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);

                if (status == TransactionStatus.Successfull)
                {
                    expectedTr.Add(curTransaction);
                }

                this.chainBlock.Add(curTransaction);
            }

            ITransaction succesfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expectedTr.Add(succesfulTransaction);
            this.chainBlock.Add(succesfulTransaction);
            IEnumerable<string> actualTr = this.chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expectedTrResult = expectedTr.OrderByDescending(tr => tr.Amount).Select(tr => tr.To);
            CollectionAssert.AreEqual(expectedTrResult, actualTr);
        }

        [Test]
        public void TestAllReceiversTransactionsWithGivenStatusToThrowException()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Failed;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 * i + 1;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(curTransaction);

                Assert.That(() =>
                {
                    this.chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
                }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionsWithGivenStatusForThatReceiver));
            }
        }


        [Test]
        public void GetAllOrderedByAmountThenByIdWithNoDuplicatedAmount()
        {
            ICollection<ITransaction> expectedTr = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)(i % 4);
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            IEnumerable<ITransaction> expectedResultTr = expectedTr.OrderByDescending(tr => tr.Amount).ThenByDescending(tr => tr.Id);
            IEnumerable<ITransaction> actualTr = this.chainBlock.GetAllOrderedByAmountDescendingThenById();
            CollectionAssert.AreEqual(expectedResultTr, actualTr);
        }

        [Test]
        public void GetAllOrderedByAmountThenByIdWithDuplicatedAmount()
        {
            ICollection<ITransaction> expectedTr = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)(i % 4);
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            ITransaction duplicatedTr = new Transaction(12, TransactionStatus.Successfull, "From20", "To20", 11);
            expectedTr.Add(duplicatedTr);
            this.chainBlock.Add(duplicatedTr);
            IEnumerable<ITransaction> expectedResultTr = expectedTr.OrderByDescending(tr => tr.Amount).ThenByDescending(tr => tr.Id);
            IEnumerable<ITransaction> actualTr = this.chainBlock.GetAllOrderedByAmountDescendingThenById();
            CollectionAssert.AreEqual(expectedResultTr, actualTr);
        }

        [Test]
        public void GetAllOrderedByAmountThenByIdWithEmptyCollection()
        {
            IEnumerable<ITransaction> actualTr = this.chainBlock.GetAllOrderedByAmountDescendingThenById();
            CollectionAssert.IsEmpty(actualTr);
        }

        [Test]
        public void GetAllSenderTransactionsByTheAmountDecending()
        {
            string sender = "From";

            ICollection<ITransaction> expectedTr = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = sender;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 20 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            IEnumerable<ITransaction> expectedResultTr = expectedTr.Where(tr => tr.From == sender).OrderByDescending(tr => tr.Amount);
            IEnumerable<ITransaction> actualTr = this.chainBlock.GetBySenderOrderedByAmountDescending(sender);
            CollectionAssert.AreEqual(expectedResultTr, actualTr);
        }

        [Test]
        public void GelAllByNotExistingSenderShouldThrowException()
        {
            string sender = "NotExisting";

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(curTransaction);
            }

            Assert.That(() =>
            {
                this.chainBlock.GetBySenderOrderedByAmountDescending(sender);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.SenderNotFound));
        }


        [Test]
        public void TestIfGetByReceiverWorksCorrectlyWithNoDuplicateAmounts()
        {
            string receiver = "To";
            ICollection<ITransaction> expectedTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = receiver;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 20 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            IEnumerable<ITransaction> expectedResultTr
                = expectedTr.Where(tr => tr.To == receiver).OrderBy(tr => tr.Amount).ThenBy(tr => tr.Id);

            IEnumerable<ITransaction> actualTr = this.chainBlock.GetByReceiverOrderedByAmountThenById(receiver);
            CollectionAssert.AreEqual(expectedResultTr, actualTr);
        }

        [Test]
        public void TestIfGetByReceiverWorksCorrectlyWithDuplicateAmounts()
        {
            string receiver = "To";
            ICollection<ITransaction> expectedTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = receiver;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 20 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            ITransaction duplicatedTr = new Transaction(15, TransactionStatus.Successfull, "From15", receiver, 11);
            expectedTr.Add(duplicatedTr);
            this.chainBlock.Add(duplicatedTr);
            IEnumerable<ITransaction> expectedResultTr
                = expectedTr.Where(tr => tr.To == receiver).OrderBy(tr => tr.Amount).ThenBy(tr => tr.Id);

            IEnumerable<ITransaction> actualTr = this.chainBlock.GetByReceiverOrderedByAmountThenById(receiver);
            CollectionAssert.AreEqual(expectedResultTr, actualTr);
        }

        [Test]
        public void GetByReceiverShouldThrowsException()
        {
            string receiver = "NotExisting";
            ICollection<ITransaction> expectedTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(curTransaction);
            }

            Assert.That(() =>
            {
                this.chainBlock.GetByReceiverOrderedByAmountThenById(receiver);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.ReceiverNotFound));
        }

        [Test]
        public void ChainBlockEnumerator()
        {
            ICollection<ITransaction> expectedTr = new List<ITransaction>();
            ICollection<ITransaction> actualTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "From" + i;
                string to = "To" + i;
                double amount = 10 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                expectedTr.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            foreach (ITransaction tr in this.chainBlock)
            {
                actualTr.Add(tr);
            }

            CollectionAssert.AreEqual(expectedTr, actualTr);
        }

        [Test]
        public void ReturnTransactionColllectionByTransactionStatusAndMaximumAmount()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();
            double maxAmount = 10;
            TransactionStatus requestedSt =  TransactionStatus.Successfull;

            for (int i = 0; i < 16; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)(i % 4);
                string from = "From" + i;
                string to = "To";
                double amount = 5 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);
                transactions.Add(curTransaction);
                this.chainBlock.Add(curTransaction);
            }

            IEnumerable<ITransaction> expectedTr = transactions.Where(tr => tr.Status == requestedSt).Where(tr => tr.Amount <= maxAmount);
            IEnumerable<ITransaction> actual = this.chainBlock.GetByTransactionStatusAndMaximumAmount(requestedSt, maxAmount);
            CollectionAssert.AreEqual(expectedTr, actual);
        }

        [Test]
        public void ReturnEmptyTransactionCollectionByTransactionStatusAndMaximumAmount()
        {
            double maxAmount = 4;
            TransactionStatus requestedSt = TransactionStatus.Successfull;

            for (int i = 0; i < 16; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)(i % 4);
                string from = "From" + i;
                string to = "To";
                double amount = 5 + i;
                ITransaction curTransaction = new Transaction(id, status, from, to, amount);

                this.chainBlock.Add(curTransaction);
            }

            IEnumerable<ITransaction> actual = this.chainBlock.GetByTransactionStatusAndMaximumAmount(requestedSt, maxAmount);
            CollectionAssert.IsEmpty(actual);
        }
    }
}
