using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        private const double VALUE = 2.00;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.radius, VALUE);
        }

        public override double CalculatePerimeter()
        {
            return VALUE * Math.PI * radius;
        }

        public override string Draw() => $"{base.Draw()} {this.GetType().Name}";

    }
}
