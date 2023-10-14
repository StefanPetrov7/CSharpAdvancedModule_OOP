
namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double WEIGHT_INCREASE = 0.35;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            "Vegetable",
            "Meat",
            "Fruit",
            "Seeds",
        };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize, allowedFoods, WEIGHT_INCREASE)
        { }

        public override string Sound() => "Cluck";

    }
}

