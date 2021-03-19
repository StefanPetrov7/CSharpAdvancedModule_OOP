using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double minCubicCs = 3000;
        private const int minHP = 250;
        private const int maxHP = 450;

        public SportsCar(string model, int hp)
            : base(model, hp, minCubicCs, minHP, maxHP)
        { }

    }
}