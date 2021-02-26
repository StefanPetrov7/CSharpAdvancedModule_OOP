namespace Animals
{
    public abstract class Animal
    {
        protected string name;
        protected string favouriteFood;

        public Animal(string name, string food)
        {
            this.name = name;
            this.favouriteFood = food;
        }

        public virtual string ExplainSelf()
        {
            return string.Format("I am {0} and my fovourite food is {1}", this.name, this.favouriteFood);
        }
    }
}
