using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Square("Red", 5.0));
            shapes.Add(new Rectangle("Blue", 4.0, 6.0));
            shapes.Add(new Circle("Green", 3.0));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {shape.Color}, Area: {shape.GetArea():F2}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
