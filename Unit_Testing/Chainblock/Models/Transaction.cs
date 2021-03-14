using System;
using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private const int MIN_ID_VAL = 0;
        private const double MIN_AMOUNT = 0;
        private int id;
        private TransactionStatus transactionStatus;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id,TransactionStatus transactionStatus ,string from, string to, double amount)
        {
            this.Id = id;
            this.Status = transactionStatus;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }


        public int Id
        { 
            get
            {
                return this.id;
            }
            set
            {
                if (value <= MIN_ID_VAL)
                {
                    throw new ArgumentException(ExceptionMessages.InvalideIdMessage);
                }

                this.id = value;
            }
        }

        public TransactionStatus Status
        {
            get { return this.transactionStatus; }
            set
            {
                this.transactionStatus = value;
            }
        }

        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalideSenderUserNameMEssage);
                }

                this.from = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalideReceiverUserNameMEssage);
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value <= MIN_AMOUNT)
                {
                    throw new ArgumentException(ExceptionMessages.InvalideAmountMessage);
                }
                this.amount = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ITransaction transaction)
            {
                return this.Id == transaction.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
