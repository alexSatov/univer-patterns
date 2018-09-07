using System;

namespace Example_07.Homework
{
    public class ExitState : IState
    {
        public int Delivery { get; set; }

        public void PrintMessage(CopyMachine copyMachine)
        {
            Console.WriteLine("Вы хотите распечатать еще один документ? (да/нет)");
        }

        public void GetValueFromUser(CopyMachine copyMachine, string value)
        {
            if (value != "да" && value != "нет")
                throw new ArgumentException("Некорректный ответ");

            if (value == "нет")
            {
                Delivery = copyMachine.CurrentSum;
                copyMachine.CurrentSum = 0;
                PrintResult(copyMachine);
                copyMachine.State = new PaymentState();
            }

            if (value == "да") copyMachine.State = new DocSelectionState();
        }

        public void PrintResult(CopyMachine copyMachine)
        {
            Console.WriteLine($"Ваша сдача: {Delivery}");
        }
    }
}