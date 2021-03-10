using System;
namespace Bank_Account
{
    public class BankAccount
    {
        private decimal amount;

        public BankAccount(decimal initialAmount)
        {
            this.amount = initialAmount;
        }

        public decimal Amount
        {
            get { return this.amount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be possitive");
                }

                this.amount = value;
            }
        }

        public void Deposit(decimal amountDeposit)
        {
            if (amountDeposit < 0)
            {
                throw new ArgumentException("Deposit must be possitiove number");
            }
            this.Amount += amountDeposit;
        }
    }
}
