using System;
namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultFuelConsummption = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }


        public override double FuelConsumption
        {
            get { return defaultFuelConsummption; }
            set { value = defaultFuelConsummption; } // can be skipped.
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
