using Vehicles.Common;
namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQty;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double capacity)
        {
            this.TankCapacity = capacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        protected virtual double RefuelProblem { get; }

        protected virtual double AirCondition { get; }

        public double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(ExceptionMessages.InvalideTankCapacity);
                }

                this.tankCapacity = value;
            }
        }

        public virtual double FuelQuantity
        {
            get => this.fuelQty;
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

        public virtual string Drive(double distance)
        {
            double fuelNeeded = (this.FuelConsumption + this.AirCondition) * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return string.Format(ExceptionMessages.TraveledDistance, this.GetType().Name, distance);
            }
            else
            {
                return string.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name);
            }
        }

        public virtual void Refuel(double incomingFuel)
        {

            if (incomingFuel <= 0)
            {
                throw new Exception(ExceptionMessages.FuelMustBePossitiveNumebr);
            }

            if (this.FuelQuantity + incomingFuel > this.TankCapacity)
            {
                throw new Exception(string.Format(ExceptionMessages.CannotFitFuel, incomingFuel));
            }

            if (this.RefuelProblem > 0)
            {
                incomingFuel *= this.RefuelProblem;
            }

            this.FuelQuantity += incomingFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

