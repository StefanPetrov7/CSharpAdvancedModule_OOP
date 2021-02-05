using System;
namespace NeedForSpeed
{
    public class Vehicle
    {

        private const double defaultFuelConsummption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption
        {
            get { return defaultFuelConsummption; }
            set { value = defaultFuelConsummption; } // can be skipped.
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
