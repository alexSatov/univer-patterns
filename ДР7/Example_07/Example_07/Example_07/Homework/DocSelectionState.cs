using System;

namespace Example_07.Homework
{
    public class DocSelectionState : IState
    {
        public string Doc { get; set; }

        public void PrintMessage(CopyMachine copyMachine)
        {
            Console.WriteLine("Введите название документа");
        }

        public void GetValueFromUser(CopyMachine copyMachine, string value)
        {
            Doc = value;
            PrintResult(copyMachine);
            // Изменяется текущая сумма
            copyMachine.State = new DocPrinterState();
            copyMachine.State.GetValueFromUser(copyMachine, Doc);
        }

        public void PrintResult(CopyMachine copyMachine)
        {
            Console.WriteLine($"Выбран документ {Doc}");
        }
    }
}