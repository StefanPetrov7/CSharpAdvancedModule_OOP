﻿using System;

namespace Restaurant.Models.Food
{
    public class Food: Product
    {
        public Food(string name, decimal price, double grams): base(name, price)
        {
            this.Grams = grams;
        }

        public virtual double Grams { get; set; }
    }
}
