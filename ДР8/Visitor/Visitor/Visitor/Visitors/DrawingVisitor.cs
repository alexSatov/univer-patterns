using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class DrawingVisitor : IGraphicVisitor
    {
        public void Visit(Rectangle rectangle)
        {
            Console.WriteLine($"Нарисован прямоугольник с центром в точке {rectangle.CenterLocation}");
        }

        public void Visit(Triangle triangle)
        {
            Console.WriteLine($"Нарисован треугольник с центром в точке {triangle.CenterLocation}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Нарисован круг с центром в точке {circle.CenterLocation}");
        }
    }
}