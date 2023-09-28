using Pizza_Calories.Common;
using Pizza_Calories.Validators;

namespace Pizza_Calories.Models
{
    public class Pizza
    {
        private string name;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.PizzaNameValidator(value);
                this.name = value;
            }
        }

        private ICollection<Topping> Toppings { get; set; }

        public int ToppingCount => this.Toppings.Count;

        public Dough Dough { get; set; }

        public double Calories => this.Dough.Calories + this.Toppings.Sum(x => x.Calories);

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count == 10)
            {
                throw new ArgumentException(GlobalConstants.EXCESSIVE_TOOPINGS);
            }

            this.Toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories.";
        }
    }
}

