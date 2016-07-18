using System;
using System.Collections.Generic;
using System.Text;

namespace commands
{
    public class ReadValueCommand : ReactiveCommand
    {
        public ReadValueCommand()
        {

        }

        public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
        {
            port1.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);
            port2.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);
                        
        }

        public void react(char[] answerData1, char[] answerData2)
        {
            Console.Write(answerData1);
            Console.Write("\n");
            Console.Write(answerData2);
            Console.Write("\n");
            Console.Write("\n");
        }

        public bool isCorrectAnswerFormat(char[] answerData)
        {
            return true;
        }
    }
}