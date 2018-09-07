using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class AreaCalculatingVisitor : IParamsVisitor
    {
        public double Visit(Rectangle rectangle)
        {
            return rectangle.Width * rectangle.Height;
        }

        public double Visit(Triangle triangle)
        {
            var p = (triangle.A + triangle.B + triangle.C) / 2.0;
            return Math.Sqrt(p * (p - triangle.A) * (p - triangle.B) * (p - triangle.C));
        }

        public double Visit(Circle circle)
        {
            return Math.PI * circle.Radius * circle.Radius;
        }
    }
}