using System;

namespace Example_08.Visitor.NotVisitor
{
    public abstract class Homeplants
    {
        public abstract string Name { get; }
        public abstract void Watering();

        public abstract void Care();
    }

    public abstract class Cactus : Homeplants
    {
        public override void Care()
        {
            Console.WriteLine("Add nutrients for cacti");
        }
    }

    public class LongCactus : Cactus
    {
        public override string Name => "LongCactus";

        public override void Watering()
        {
            Console.WriteLine("Watering with special salts");
        }
    }

    public class RoundCactus : Cactus
    {
        public override string Name => "RoundCactus";

        public override void Watering()
        {
            Console.WriteLine("Watering one time on month");
        }
    }

    public class Aloe : Homeplants
    {
        public override string Name => "Aloe";
        public override void Watering()
        {
            Console.WriteLine("SomeWatering");
        }

        public override void Care()
        {
            Console.WriteLine("SomeCare");
        }
    }
}
