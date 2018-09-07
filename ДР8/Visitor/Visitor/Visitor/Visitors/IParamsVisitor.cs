using Visitor.Figures;

namespace Visitor.Visitors
{
    public interface IParamsVisitor
    {
        double Visit(Rectangle rectangle);
        double Visit(Triangle triangle);
        double Visit(Circle circle);
    }
}