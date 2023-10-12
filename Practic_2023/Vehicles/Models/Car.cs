using System;
namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AC_INCREASE = 0.9;
        private const double REFULING_PROBLEM = 0;


        public Car(double fuelQuantity, double fuelConsumption, double capacity)
            : base(fuelQuantity, fuelConsumption, capacity)
        { }

        protected override double AirCondition => AC_INCREASE;

        protected override double RefuelProblem => REFULING_PROBLEM;

    }
}

