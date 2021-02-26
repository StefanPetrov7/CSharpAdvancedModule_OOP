namespace Practice_Polymorphism
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
