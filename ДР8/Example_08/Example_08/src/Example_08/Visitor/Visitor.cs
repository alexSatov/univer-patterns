using System;

namespace Example_08.Visitor.Vsisitor
{
    public interface IVisitor
    {
        string OperationName { get; }
        void Visit(VisLongCactus cactus);
        void Visit(VisRoundCactus cactus);
        void Visit(VisAloe cactus);
    }

    public class WateringVisitor : IVisitor
    {
        public string OperationName => "Watering";

        public void Visit(VisLongCactus cactus)
        {
            Console.WriteLine("Watering with special salts");
        }

        public void Visit(VisRoundCactus cactus)
        {
            Console.WriteLine("Watering one time on month");
        }

        public void Visit(VisAloe cactus)
        {
            Console.WriteLine("SomeWatering");
        }
    }

    public class CareVisitor : IVisitor
    {
        public string OperationName => "Caring";

        public void Visit(VisLongCactus cactus)
        {
            Console.WriteLine("Add nutrients for cacti");
        }

        public void Visit(VisRoundCactus cactus)
        {
            Console.WriteLine("Add nutrients for cacti");
        }

        public void Visit(VisAloe cactus)
        {
            Console.WriteLine("SomeCare");
        }
    }

    public abstract class VisHomeplants
    {
        public abstract string Name { get; }

        public abstract void Accept(IVisitor visitor);
    }
    
    public class VisLongCactus : VisHomeplants
    {
        public override string Name => "VisLongCactus";
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class VisRoundCactus : VisHomeplants
    {
        public override string Name => "VisRoundCactus";
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class VisAloe : VisHomeplants
    {
        public override string Name => "VisAloe";
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


}
