
namespace WildFarm.Models
{
    public abstract class Bird : Animal
    {

        public Bird(string name, double weight, double wingSize, HashSet<string> allowedFoods, double weightIncrease)
            : base(name, weight, allowedFoods, weightIncrease)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}

