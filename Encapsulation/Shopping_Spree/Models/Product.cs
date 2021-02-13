using System;
using Shopping_Spree.Common;

namespace Shopping_Spree.Models
{
    public class Product
    {
        private string name;
         
        private decimal prise;

        public Product(string name, decimal prise)
        {
            Name = name;
            Prise = prise;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXEP_MSG);
                }

                name = value;

            }
        }

        public decimal Prise
        {
            get { return prise; }

            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(GlobalConstants.ERROR_MSG_MONEY);
                }

                prise = value;
            }
        }

        public override string ToString() => $"{Name}";

    }
}
