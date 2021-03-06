using System;
using System.Collections.Generic;

namespace Example_08.CommandNamespace
{
    public enum OperationType
    {
        /// <summary>
        /// Сложение
        /// </summary>
        Add,

        /// <summary>
        /// Вычитание
        /// </summary>
        Sub
    }

    public abstract class Command
    {
        protected readonly Calculator Calculator;
        protected readonly int Operand;

        protected Command(Calculator calc, int operand)
        {
            Calculator = calc;
            Operand = operand;
        }

        public void Execute()
        {
            Calculator.Operation(Operation, Operand);
        }

        public void Rollback()
        {
            Calculator.Operation(RollbackOperation, Operand);
        }

        protected abstract OperationType Operation { get; }
        protected abstract OperationType RollbackOperation { get; }
    }

    public class AddCommand : Command
    {
        public AddCommand(Calculator calc, int operand) : base(calc, operand)
        { }

        protected override OperationType Operation => OperationType.Add;
        protected override OperationType RollbackOperation => OperationType.Sub;
    }

    public class SubCommand : Command
    {
        public SubCommand(Calculator calc, int operand) : base(calc, operand)
        { }

        protected override OperationType Operation => OperationType.Sub;
        protected override OperationType RollbackOperation => OperationType.Add;
    }

    //Receiver
    public class Calculator
    {
        private int _result = 0;

        public void Operation(OperationType operation, int operand)
        {
            switch (operation)
            {
                case OperationType.Add:
                    _result += operand;
                    break;
                case OperationType.Sub:
                    _result -= operand;
                    break;
                default:
                    throw new NotSupportedException(nameof(operation));
            }

            Console.WriteLine($"Current value: {_result}, after \"{operation}:{operand}\"");
        }
    }

    public class CalculatorInvoker
    {
        protected Calculator Calc = new Calculator();
        protected List<Command> Commands = new List<Command>();
        protected int Current = 0;
        
        public void Calculate(OperationType operation, int operand)
        {
            Console.WriteLine("Calculate");
            var command = CreateComand(operation, operand);
            command.Execute();

            if (Current < Commands.Count)
            {
                Commands.RemoveRange(Current, Commands.Count - Current);
            }

            Commands.Add(command);
            Current++;
        }

        public void Undo(int steps = 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Undo {steps} steps");
            for (int i = 0; i < steps; i++)
            {
                if (Current > 0)
                {
                    Commands[--Current].Rollback();
                }
            }
            Console.ResetColor();
        }

        public void Redo(int steps = 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Redo {steps} steps");
            for (int i = 0; i < steps; i++)
            {
                if (Current < Commands.Count)
                {
                    Commands[Current++].Execute();
                }
            }
            Console.ResetColor();
        }

        private Command CreateComand(OperationType operation, int operand)
        {
            switch (operation)
            {
                case OperationType.Add:
                    return new AddCommand(Calc, operand);
                case OperationType.Sub:
                    return new SubCommand(Calc, operand);
                default:
                    throw new NotSupportedException(nameof(operation));
            }
        }
    }
}
