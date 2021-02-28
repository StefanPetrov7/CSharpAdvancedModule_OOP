namespace Vehicles.Models
{
    public class Car : Viechle
    {
        private const double AIR_CONDITION_FUEL_INCREASE = 0.9;
        private const double REFUILING_PROBLEM = 0.0;

        public Car(double fuelQty, double fuelConsumption, double tankCapacity)
            : base(fuelQty, fuelConsumption, tankCapacity)
        {
        }

        protected override double AirCondition => AIR_CONDITION_FUEL_INCREASE;

        protected override double RefulingProblem => REFUILING_PROBLEM;


    }
}
