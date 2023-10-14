
namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREASE = 0.1;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            "Vegetable",
            "Fruit",
        };

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, allowedFoods, WEIGHT_INCREASE)
        { }

        public override string Sound() => "Squeak";

    }
}

