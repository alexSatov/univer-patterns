using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example_08.CommandNamespace;

namespace Example_08.Memento
{
    public interface IMemento
    {
        void Restore();
    }

    public class CalculatorOrdinator
    {
        private class CalculatorMemento : IMemento
        {

            private readonly int result;
            private readonly CalculatorOrdinator _ordinator;

            public CalculatorMemento(CalculatorOrdinator ordinator, int state)
            {
                result = state;
                _ordinator = ordinator;
            }

            public void Restore()
            {
                _ordinator._result = result;
            }
        }

        private int _result;

        public void Add(int operand)
        {
            _result += operand;
        }

        public IMemento GetMemento()
        {
            return new CalculatorMemento(this, _result);
        }

        public int Result => _result;
    }
}
