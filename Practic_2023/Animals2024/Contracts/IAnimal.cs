using Polymorphism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Contracts
{
    public  interface IAnimal
    {
        public string Name { get;  }

        public double Weight { get;  }

        public int FoodEaten { get; }

        string ProduceSound();

        bool EatFood(Food food);
    }
}
