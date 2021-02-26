namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        private const double VALUE = 2.00;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return (this.height + this.width) * VALUE;
        }

        public override string Draw() => $"{base.Draw()} {this.GetType().Name}";

    }
}
