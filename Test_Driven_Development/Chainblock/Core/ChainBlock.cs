using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Core
{
    public class ChainBlock : IChainblock
    {
        private ICollection<ITransaction> transactions;


        public ChainBlock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx.Id))
            {
                throw new InvalidOperationException(ExceptionMessages.TransactionHasBeenAddedAlready);
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.Any(tr => tr.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NoSuchTransaction);
            }

            this.transactions.Where(tr => tr.Id == id).FirstOrDefault().Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(tr => tr.Id == tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(tr => tr.Id == id);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> resultTr = this.transactions.OrderByDescending(tr => tr.Amount).ThenByDescending(transactions => transactions.Id);
            return resultTr;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> resultTr =
          this.transactions.Where(tr => tr.Status == status).OrderByDescending(tr => tr.Amount).Select(tr => tr.To);

            if (resultTr.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionsWithGivenStatusForThatReceiver);
            }

            return resultTr;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> resultTr =
                this.transactions.Where(tr => tr.Status == status).OrderByDescending(tr => tr.Amount).Select(tr => tr.From);

            if (resultTr.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionsWithGivenStatusFromThatSender);
            }

            return resultTr;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(tr => tr.Id == id);

            return transaction ?? throw new ArgumentException(ExceptionMessages.NoSuchTransaction);
        }


        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> resultTr
           = this.transactions.Where(tr => tr.To == receiver).OrderBy(tr => tr.Amount).ThenBy(tr => tr.Id);

            if (resultTr.Count() == 0 || resultTr == null)
            {
                throw new InvalidOperationException(ExceptionMessages.ReceiverNotFound);
            }

            return resultTr;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> resultTr
                = this.transactions.Where(tr => tr.From == sender).OrderByDescending(tr => tr.Amount);

            if (resultTr.Count() == 0 || resultTr == null)
            {
                throw new InvalidOperationException(ExceptionMessages.SenderNotFound);
            }

            return resultTr;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(tr => tr.Status == status).OrderByDescending(tr => tr.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionsWithGivenStatus);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> resultCollection
                = this.transactions.Where(tr => tr.Status == status).Where(tr => tr.Amount <= amount);
            return resultCollection;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.GetById(id);
            this.transactions.Remove(transaction);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            { 
                 yield return this.transactions.ToArray()[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }    
    }
}
