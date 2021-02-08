using System;
namespace Point_in_Rectangle
{
    public class Circle
    {
        public Circle(int x, int y, int radius)
        {
            this.Center = new Point(x, y);
            this.Radius = radius;
        }

        public Point Center { get; set; }

        public int Radius { get; set; }

        public bool Contains(Point point)
        {
            // Pitagor T - implementation
            double distance = Math.Sqrt((point.X - Center.X) * (point.X - Center.X) +
                (point.Y - Center.Y) * (point.Y - Center.Y));

            return distance <= this.Radius;
         
        }
    }
}
 