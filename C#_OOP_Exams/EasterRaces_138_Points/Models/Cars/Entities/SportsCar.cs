using System;
namespace EasterRaces.Models.Cars.Entities
{
	public class SportsCar: Car
	{
        private const int MIN_HP = 250;
        private const int MAX_HP = 450;
        private const int CUBIC_METRERS = 3000;

        public SportsCar(string model, int hp)
            : base(model, hp, CUBIC_METRERS, MIN_HP, MAX_HP)
        { }
    }
}