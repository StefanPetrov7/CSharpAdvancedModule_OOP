using System;
namespace Point_in_Rectangle
{
    public class Rectangle
    {

        public Rectangle(int top, int left, int bottom, int right)
        {
            this.TopLeft = new Point(top, left);
            this.BottomRight = new Point(bottom, right);
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool ContainsPoint(Point point)
        {
            bool isInX = point.X >= TopLeft.X && point.X <= BottomRight.X;

            bool isInY =  point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;

            return isInX & isInY;
        }
    }
}
