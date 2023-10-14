
namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double WEIGHT_INCREASE = 0.4;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            "Meat",
        };

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, allowedFoods, WEIGHT_INCREASE)
        { }

        public override string Sound() => "Woof!";

    }
}

