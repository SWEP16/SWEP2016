using System;
using System.Collections.Generic;
using System.Text;

namespace commands
{
    namespace reactivecommands
    {
        public interface ReactiveCommand
        {
            void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2);
            void react(char[] answerData1, char[] answerData2);
            bool isCorrectAnswerFormat(char[] answerData);
        }
    }
}
