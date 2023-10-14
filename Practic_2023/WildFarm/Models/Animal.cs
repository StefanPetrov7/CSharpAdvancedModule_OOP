using WildFarm.Common;
using WildFarm.Exceptios;
using WildFarm.Models.Foods;
namespace WildFarm.Models
{
    public abstract class Animal
    {

        private double WEIGHT_INCRESASE;

        public Animal(string name, double weight, HashSet<string> allowedFoods, double weightIncrease)
        {
            this.Name = name;
            this.Weight = weight;
            this.AllowedFood = allowedFoods;
            this.WEIGHT_INCRESASE = weightIncrease;
        }

        private HashSet<string> AllowedFood;

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; set; }

        public abstract string Sound();

        public void Eat(Food food)
        {
            if (this.AllowedFood.Contains(food.GetType().Name))
            {
                this.Weight += this.WEIGHT_INCRESASE * food.Qty;
                this.FoodEaten += food.Qty;

            }
            else
            {
                throw new InvalidFoodException(string.Format(GlobConst.IVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

