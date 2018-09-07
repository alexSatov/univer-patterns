using Visitor.Visitors;

namespace Visitor.Figures
{
    public class Triangle : IFigure
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public Point CenterLocation { get; set; }

        public Triangle(int a, int b, int c, Point location)
        {
            A = a;
            B = b;
            C = c;
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