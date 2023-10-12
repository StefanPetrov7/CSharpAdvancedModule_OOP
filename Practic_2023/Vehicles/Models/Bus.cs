using System;
namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AC_INCREASE = 1.4;
        private const double REFULING_PROBLEM = 0;


        public Bus(double fuelQuantity, double fuelConsumption, double capacity)
            : base(fuelQuantity, fuelConsumption, capacity)
        { }

        public bool IsEmpty { get; set; }

        protected override double AirCondition => this.IsEmpty ? 0 : AC_INCREASE;

        protected override double RefuelProblem => REFULING_PROBLEM;

    }
}

