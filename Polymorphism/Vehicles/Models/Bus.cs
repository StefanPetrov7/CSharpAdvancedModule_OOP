namespace Vehicles.Models
{
    public class Bus : Viechle
    {
        private const double AIR_CONDITION_FUEL_INCREASE = 1.4;
        private const double REFUILING_PROBLEM = 0.0;

        public Bus(double fuelQty, double fuelConsumption, double tankCapacity)
            : base(fuelQty, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        protected override double AirCondition => IsEmpty ? 0.0 : AIR_CONDITION_FUEL_INCREASE;

        protected override double RefulingProblem => REFUILING_PROBLEM;

    }
}
