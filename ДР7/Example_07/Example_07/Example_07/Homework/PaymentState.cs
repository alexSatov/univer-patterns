using System;

namespace Example_07.Homework
{
    public class PaymentState : IState
    {
        public int Sum { get; set; }

        public void PrintMessage(CopyMachine copyMachine)
        {
            Console.WriteLine("Внесите деньги");
        }

        public void GetValueFromUser(CopyMachine copyMachine, string value)
        {
            try
            {
                Sum = int.Parse(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите число!");
                return;
            }
            PrintResult(copyMachine);
            copyMachine.CurrentSum = Sum;
            copyMachine.State = new DeviceSelectionState();
        }

        public void PrintResult(CopyMachine copyMachine)
        {
            Console.WriteLine($"Текущая сумма: {Sum}");
        }
    }
}