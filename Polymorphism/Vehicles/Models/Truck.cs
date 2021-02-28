namespace Vehicles.Models
{
    public class Truck : Viechle
    {
        private const double AIR_CONDITION_FUEL_INCREASE = 1.6;
        private const double REFUILING_PROBLEM = 0.95;

        public Truck(double fuelQty, double fuelConsumption, double tankCapacity)
            : base(fuelQty, fuelConsumption, tankCapacity)
        {
        }

        protected override double AirCondition => AIR_CONDITION_FUEL_INCREASE;

        protected override double RefulingProblem => REFUILING_PROBLEM;

    }
}
