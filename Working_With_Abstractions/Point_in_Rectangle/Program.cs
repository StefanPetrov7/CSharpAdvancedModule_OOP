using System;
using System.Linq;

namespace Point_in_Rectangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] rectanglePoints = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int xTopLeft = rectanglePoints[0];
            int yTopLeft = rectanglePoints[1];
            int bottomRightX = rectanglePoints[2];
            int bottomRightY = rectanglePoints[3];

            int n = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(xTopLeft, yTopLeft, bottomRightX, bottomRightY);

            for (int i = 0; i < n; i++)
            {
                int[] pointsXy = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

                Point point = new Point(pointsXy[0], pointsXy[1]);

                Console.WriteLine(rectangle.ContainsPoint(point));
            }

            Circle circle = new Circle(0, 0, 2);
            Console.WriteLine(circle.Contains(new Point(0,0)));
            Console.WriteLine(circle.Contains(new Point(0, 2)));
            Console.WriteLine(circle.Contains(new Point(2, 0)));
            Console.WriteLine(circle.Contains(new Point(3, 0)));
        }
    }
}
