using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Shape rectangle = new Rectangle(5, 5);
            //Shape circle = new Circle(5);

            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Rectangle(5, 5));
            shapes.Add(new Circle(5));

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw()); 
            }
        }
    }
}
