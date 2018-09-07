using Visitor.Visitors;

namespace Visitor.Figures
{
    public class Circle : IFigure
    {
        public double Radius { get; set; }
        public Point CenterLocation { get; set; }

        public Circle(double radius, Point location)
        {
            Radius = radius;
            CenterLocation = location;
        }

        public void Accept(IGraphicVisitor grVisitor)
        {
            grVisitor.Visit(this);
        }

        public void Accept(IParamsVisitor parVisitor)
        {
            parVisitor.Visit(this);
        }
    }
}