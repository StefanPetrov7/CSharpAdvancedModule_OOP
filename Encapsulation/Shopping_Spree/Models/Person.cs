using System;
using System.Collections.Generic;
using System.Text;
using Shopping_Spree.Common;

namespace Shopping_Spree.Models
{
    public class Person
    {

        private const string ERROR_MSG_NOT_ENOUGH_MONEY = "{0} can't afford {1}";

        private const string PUCHACSE_MSG = "{0} bought {1}";

        private const string NOTHIG_BOUGHT = "Nothing bought";

        private string name;

        private decimal money;

        private readonly ICollection<Product> bag; // => ICollection allow us to use diffrenet structures, LIST,HASHSET etc.

        private Person()
        {
            bag = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXEP_MSG);
                }

                name = value;

            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.ERROR_MSG_MONEY);
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag   // => The collection will not be accessible out from the class.
        {
            get => (IReadOnlyCollection<Product>)this.bag;
        }


        public void BuyProduct(Product product)
        {
            if (product.Prise <= Money)
            {
                Money -= product.Prise;
                bag.Add(product);
                Console.WriteLine(string.Format(PUCHACSE_MSG, this.Name, product.Name));
            }
            else
            {
                Console.WriteLine(string.Format(ERROR_MSG_NOT_ENOUGH_MONEY, this.Name, product.Name));
            }
        }

        public override string ToString()
        {
            string output = bag.Count > 0 ? $"{Name} - {string.Join(", ", bag)}" : $"{Name} - {NOTHIG_BOUGHT}";
            return output.TrimEnd();

            //StringBuilder sb = new StringBuilder();    // => StringBuilder version.

            //if (bag.Count > 0)
            //{
            //    sb.Append($"{Name} - {string.Join(", ", bag)}");
            //}
            //else
            //{
            //    sb.Append(Name + " - " + NOTHIG_BOUGHT);
            //}

            //return sb.ToString().Trim();
        }
    }
}
