namespace Example_07.Homework
{
    public interface IState
    {
        void PrintMessage(CopyMachine copyMachine);
        void GetValueFromUser(CopyMachine copyMachine, string value);
        void PrintResult(CopyMachine copyMachine);
    }
}