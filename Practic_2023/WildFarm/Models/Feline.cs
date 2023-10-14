
namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed, HashSet<string> allowedFoods, double weightIncrease)
            : base(name, weight, livingRegion, allowedFoods, weightIncrease)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            List<string> text = base.ToString().Split(" ").ToList();
            text.Insert(2, $"{this.Breed},");
            return string.Join(" ", text);
        }
    }
}

