using System;

using Vehicles.Common;

namespace Vehicles.Models
{
    public abstract class Viechle
    {
        protected double tankCapacity;
        protected double fuelQty;

        public Viechle(double fuelQty, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQty;
        }

        protected abstract double RefulingProblem { get; }

        protected abstract double AirCondition { get; }

        protected double FuelQuantity
        {
            get { return this.fuelQty; }

            private set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                this.fuelQty = value;
            }
        }

        protected double FuelConsumption { get; private set; }

        protected double TankCapacity
        {
            get { return this.tankCapacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(ExceptionMessages.InvalideTankCapacity);
                }

                this.tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            double fuelNeeded = (this.FuelConsumption + this.AirCondition) * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return string.Format(Common.ExceptionMessages.TraveledDistance, this.GetType().Name, distance);
            }
            else
            {
                throw new Exception(string.Format(Common.ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }
        }

        public void Refuel(double fuel)
        {

            if (fuel < 1)
            {
                throw new Exception(ExceptionMessages.FuelMustBePossitiveNumebr);
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new Exception(string.Format(ExceptionMessages.CannotFitFuel, fuel));
            }

            if (this.RefulingProblem > 0)
            {
                fuel *= RefulingProblem;
            }

            this.FuelQuantity += fuel;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
