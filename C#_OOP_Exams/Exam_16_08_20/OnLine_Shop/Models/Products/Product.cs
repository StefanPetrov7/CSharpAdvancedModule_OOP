using System;
using OnLine_Shop.Common.Constants;

namespace OnLine_Shop.Models.Products
{
    public abstract class Product : IProducts
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformace;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformace = overallPerformance;
        }

        public int Id
        {
            get { return this.id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                this.id = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            private set               // If protected set can be modified only by the inherited classes.
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }

        public virtual double OverallPerformace
        {
            get { return this.overallPerformace; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.overallPerformace = value;
            }
        }

        public override string ToString()
        {
            return string.Format(SuccessMesages.ProductToString,
                this.OverallPerformace.ToString("f2"),
                this.Price.ToString("f2"),
                this.GetType().Name,
                this.Manufacturer,
                this.Model,
                this.Id);
        }
    }
}
