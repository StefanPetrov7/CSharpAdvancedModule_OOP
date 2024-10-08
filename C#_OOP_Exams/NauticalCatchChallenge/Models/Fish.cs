﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string? name;
        private double points;

        public Fish(string name, double points, int timeToCatch)
        {
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }

        public string? Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FishNameNull));
                }

                this.name = value;
            }
        }

        public double Points
        {
            get
            {
                return this.points;
            }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PointsNotInRange));
                }

                this.points = value;
            }
        }

        public int TimeToCatch { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name} [ Points: {this.Points}, Time to Catch: {this.TimeToCatch} seconds ]";
        }

    }

}
