
namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double WEIGHT_INCREASE = 0.3;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            "Vegetable",
            "Meat",
        };

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, allowedFoods, WEIGHT_INCREASE)
        { }

        public override string Sound() => "Meow";
    }
}

