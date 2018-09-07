using System;
using Visitor.Figures;
using Visitor.Visitors;

namespace Visitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var figures = new IFigure[3];
            figures[0] = new Rectangle(10, 5, new Point(10, 10));
            figures[1] = new Triangle(5, 7, 3, new Point(-4, -7));
            figures[2] = new Circle(4, new Point(0, 0));

            var graphicVisitor = new DrawingVisitor(); 
            var areaCalcVisitor = new AreaCalculatingVisitor(); 
            var perimeterCalcVisitor = new AreaCalculatingVisitor();

            foreach (var figure in figures)
            {
                figure.Accept(graphicVisitor);
                figure.Accept(areaCalcVisitor);
                figure.Accept(perimeterCalcVisitor);
            }

            Console.ReadKey();
        }
    }
}
