using System;

namespace Example_07.Homework
{
    public class DeviceSelectionState : IState
    {
        public string Device { get; set; }

        public void PrintMessage(CopyMachine copyMachine)
        {
            Console.WriteLine("Выберите устройство (usb/wi-fi)");
        }

        public void GetValueFromUser(CopyMachine copyMachine, string value)
        {
            if (value != "usb" && value != "wi-fi")
                throw new ArgumentException("Неизвестное устройство");
            Device = value;
            PrintResult(copyMachine);
            copyMachine.State = new DocSelectionState();
        }

        public void PrintResult(CopyMachine copyMachine)
        {
            Console.WriteLine($"Выбрано {Device} устройство");
        }
    }
}