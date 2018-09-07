using System;
using Example_08.CommandNamespace;
using Example_08.Memento;
using Example_08.Visitor.NotVisitor;
using Example_08.Visitor.Vsisitor;

namespace Example_08
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CommandExample();
            //VisitorExample();
            MementroCaretakerExample();
            Console.ReadLine();
        }

        public static void CommandExample()
        {
            var invoker = new CalculatorInvoker();

            invoker.Calculate(OperationType.Add, 100);
            invoker.Calculate(OperationType.Sub, 50);
            invoker.Calculate(OperationType.Add, 75);

            invoker.Undo();
            invoker.Redo();

            invoker.Undo(3);
            invoker.Calculate(OperationType.Sub, 100);
            invoker.Redo();
            invoker.Redo();
        }

        public static void VisitorExample()
        {
            //Before
            Homeplants[] homeplants = { new LongCactus(), new RoundCactus(), new Aloe()} ;
            foreach (var plant in homeplants)
            {
                plant.Care();
                plant.Watering();
            }

            //after 
            Console.ForegroundColor = ConsoleColor.Green;
            VisHomeplants[] homeplants2 = {
                new VisLongCactus(),
                new VisRoundCactus(),
                new VisAloe()};

            var careVisitor = new CareVisitor();
            var waterVisitor = new WateringVisitor();
            foreach (var plant in homeplants2)
            {
                plant.Accept(careVisitor);
                plant.Accept(waterVisitor);
            }
            Console.ResetColor();
        }

        public static void MementroCaretakerExample()
        {
            var ordinator = new CalculatorOrdinator();
            var memento0 = ordinator.GetMemento();
            
            ordinator.Add(100);
            ordinator.Add(333);

            Console.WriteLine(ordinator.Result);
            var memento443 = ordinator.GetMemento();

            memento0.Restore();
            Console.WriteLine(ordinator.Result);
            memento443.Restore();
            Console.WriteLine(ordinator.Result);
        }
    }
}
