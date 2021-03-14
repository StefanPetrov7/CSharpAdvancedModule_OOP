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

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(tr => tr.Id == id);

            return transaction ?? throw new ArgumentException(ExceptionMessages.NoSuchTransaction);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
           this.transactions = this.transactions.Where(tr => tr.Status == status).OrderByDescending(tr => tr.Amount).ToList();

            if (this.transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionsWithGivenStatus);
            }

            return this.transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.transactions.GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.GetById(id);
            this.transactions.Remove(transaction);

            //if (transaction!=null)   // Not nececarry code, GetById => throws same exceptions.
            //{
            //    this.transactions.Remove(transaction);
            //}
            //else
            //{
            //    throw new ArgumentException(ExceptionMessages.NoSuchTransaction);
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
