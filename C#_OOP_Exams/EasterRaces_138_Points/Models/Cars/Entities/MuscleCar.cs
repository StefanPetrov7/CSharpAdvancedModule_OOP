using System;
namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MIN_HP = 400;
        private const int MAX_HP = 600;
        private const int CUBIC_METRERS = 5000;

        public MuscleCar(string model, int hp)
            : base(model, hp, CUBIC_METRERS, MIN_HP, MAX_HP)
        { }
    }
}

