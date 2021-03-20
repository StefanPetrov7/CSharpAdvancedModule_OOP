namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double minCubicCs = 5000;
        private const int minHP = 400;
        private const int maxHP = 600;

        public MuscleCar(string model, int hp)            // base ctor has 5 params from which 3 are prefixed in these class. 
            : base(model, hp, minCubicCs, minHP, maxHP)   // HP uses these params to validate in the base class.
        { }
    }
}
