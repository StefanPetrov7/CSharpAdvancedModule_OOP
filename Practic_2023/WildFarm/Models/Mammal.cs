
namespace WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion, HashSet<string> allowedFoods, double weightIncrease)
            : base(name, weight, allowedFoods, weightIncrease)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}

