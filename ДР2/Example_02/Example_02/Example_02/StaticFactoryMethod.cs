using System;

namespace Example_02
{
    public static class LunchFactoryHelper
    {
        public static ILunchFactory Create(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return new MondayFactory();
                case DayOfWeek.Tuesday:
                    return new TuesdayFactory();
            }
            throw new NotSupportedException();
        }
    }
}