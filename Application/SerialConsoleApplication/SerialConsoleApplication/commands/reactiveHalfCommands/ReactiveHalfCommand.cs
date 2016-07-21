using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands
{
    namespace reactivecommands
    {
        public abstract class ReactiveHalfCommand
        {
            abstract public void execute(System.IO.Ports.SerialPort port);
            abstract public void react(char[] answerData);
            abstract public bool isCorrectAnswerFormat(char[] answerData);
        }
    }
}
