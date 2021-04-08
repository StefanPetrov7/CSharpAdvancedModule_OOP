using System;
namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {
        private const double cc = 5000;
        private const int minHp = 400;
        private const int maxHp = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, cc, minHp, maxHp)
        { }
    }
}
