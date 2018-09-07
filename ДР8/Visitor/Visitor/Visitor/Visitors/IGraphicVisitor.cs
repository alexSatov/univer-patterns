using Visitor.Figures;

namespace Visitor.Visitors
{
    public interface IGraphicVisitor
    {
        void Visit(Rectangle rectangle);
        void Visit(Triangle triangle);
        void Visit(Circle circle);
    }
}