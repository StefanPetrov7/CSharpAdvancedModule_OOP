using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int hp;
        private double cubicCs;
        private int minHP;
        private int maxHP;

        private const int MIN_LETTERS = 4;

        protected Car(string model, int hp, double cubicCs, int minHP, int maxHP)
        {
            this.minHP = minHP;  // this need to be first as the HP requiers them bfor the validation.
            this.maxHP = maxHP;
            this.Model = model;
            this.HorsePower = hp;
            this.CubicCentimeters = cubicCs;
          
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LETTERS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MIN_LETTERS));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get { return this.hp; }
            private set
            {
                if (value < minHP || value > maxHP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.hp = value;
            }
        }

        public double CubicCentimeters
        {
            get { return this.cubicCs; }
            private set { this.cubicCs = value; }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
