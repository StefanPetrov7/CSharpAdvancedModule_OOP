
namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double WEIGHT_INCREASE = 1.0;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            "Meat",
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, allowedFoods, WEIGHT_INCREASE)
        { }

        public override string Sound() => "ROAR!!!";

    }
}

