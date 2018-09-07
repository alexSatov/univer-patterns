using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_07.Homework
{
    public class CopyMachine
    {
        public IState State { get; set; }
        public int CurrentSum { get; set; }

        public CopyMachine()
        {
            State = new PaymentState();
        }

        public void CurrentMessage()
        {
            State.PrintMessage(this);
        }

        public void EnterValue(string value)
        {
            State.GetValueFromUser(this, value);
        }
    }
}
