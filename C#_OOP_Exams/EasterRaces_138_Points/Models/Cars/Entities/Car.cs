using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int MIN_HP;
        private int MAX_HP;

        public Car(string model, int hp, double cMeters, int minHp, int maxHp)
        {
            this.MIN_HP = minHp;
            this.MAX_HP = maxHp;
            this.Model = model;
            this.HorsePower = hp;
            this.CubicCentimeters = cMeters;
        }

        public string Model
        {
            get => this.model;

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4)); 
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;

            set
            {
                if (value < this.MIN_HP || value > this.MAX_HP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps) => (this.CubicCentimeters / this.HorsePower) * laps;
    }
}