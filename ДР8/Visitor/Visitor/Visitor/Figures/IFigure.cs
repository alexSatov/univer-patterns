using Visitor.Visitors;

namespace Visitor.Figures
{
    public interface IFigure
    {
        Point CenterLocation { get; set; }
        void Accept(IGraphicVisitor grVisitor);
        void Accept(IParamsVisitor parVisitor);
    }
}