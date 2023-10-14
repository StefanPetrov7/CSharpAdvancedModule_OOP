
namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double WEIGHT_INCREASE = 0.25;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            "Meat",
        };

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize, allowedFoods, WEIGHT_INCREASE)
        { }

        public override string Sound() => "Hoot Hoot";

    }
}

