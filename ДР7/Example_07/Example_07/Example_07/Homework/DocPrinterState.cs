using System;

namespace Example_07.Homework
{
    public class DocPrinterState : IState
    {
        public void PrintMessage(CopyMachine copyMachine)
        {
            Console.WriteLine("Ожидайте завершения печати...");
        }

        public void GetValueFromUser(CopyMachine copyMachine, string value)
        {
            var docForPrinting = value;
            PrintMessage(copyMachine);
            // Печатается содержимое документа
            PrintResult(copyMachine);
            copyMachine.State = new ExitState();
        }

        public void PrintResult(CopyMachine copyMachine)
        {
            Console.WriteLine("Печать закончена");
        }
    }
}