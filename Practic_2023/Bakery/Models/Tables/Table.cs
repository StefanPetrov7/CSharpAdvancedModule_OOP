using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private int tableNumber;
        private decimal pricePerPerson;

        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;

        private Table()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public Table(int tableNumber, int capacity, decimal pricePerPerson) : this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber
        {
            get => this.tableNumber;
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public bool IsReserved { get; private set; }

        public decimal Price => (this.NumberOfPeople * this.PricePerPerson);

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal totalBill = 0;
            totalBill += this.foodOrders.Sum(f => f.Price);
            totalBill += this.drinkOrders.Sum(d => d.Price);
            totalBill += this.Price;
            return totalBill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:f2}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}

