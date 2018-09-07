using System;
using Visitor.Figures;

namespace Visitor.Visitors
{
    public class PerimeterCalculatingVisitor : IParamsVisitor
    {
        public double Visit(Rectangle rectangle)
        {
            return rectangle.Width * 2 + rectangle.Height * 2;
        }

        public double Visit(Triangle triangle)
        {
            return triangle.A + triangle.B + triangle.C;
        }

        public double Visit(Circle circle)
        {
            return 2 * Math.PI * circle.Radius;
        }
    }
}