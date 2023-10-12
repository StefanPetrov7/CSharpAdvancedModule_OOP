using System;
namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AC_INCREASE = 1.6;

        private const double TANK_REDUCED_CAPACITY = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double capacity)
            : base(fuelQuantity, fuelConsumption, capacity)
        { }

        protected override double RefuelProblem => TANK_REDUCED_CAPACITY;

        protected override double AirCondition => AC_INCREASE;
    }
}