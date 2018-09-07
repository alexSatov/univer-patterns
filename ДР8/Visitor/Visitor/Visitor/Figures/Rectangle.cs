using Visitor.Visitors;

namespace Visitor.Figures
{
    public class Rectangle : IFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Point CenterLocation { get; set; }

        public Rectangle(double width, double height, Point location)
        {
            Width = width;
            Height = height;
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