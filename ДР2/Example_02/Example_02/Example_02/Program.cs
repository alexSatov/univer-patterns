using System;

namespace Example_02
{
    class Program
    {
        static void Main(string[] args)
        {
           Runner.Run();

            //Меню на понедельник
            var mondayFactory = new MondayFactory();
            PrintMenu(mondayFactory);

            //Меню на вторник
            var tuesdayFactory = new TuesdayFactory();
            PrintMenu(tuesdayFactory);

            //Меню на вторник
            //PrintMenu(DayOfWeek.Tuesday);

            Console.ReadKey();
        }

        public static void PrintMenu(ILunchFactory factory)
        {
            Console.WriteLine("==== Меню на сегодня ======");

            var dish = factory.CreateHotDish();
            Console.WriteLine($"Основное блюдо: {dish.Name}");

            var dessert = factory.CreateDessert();
            Console.WriteLine($"Дессерт: {dessert.Name}");
        }

        public static void PrintMenu(DayOfWeek dayOfWeek)
        {
            var factory = LunchFactoryHelper.Create(dayOfWeek);
            PrintMenu(factory);
        }
    }
}