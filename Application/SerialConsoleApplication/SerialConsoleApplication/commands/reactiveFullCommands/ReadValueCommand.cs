using System;
using System.Collections.Generic;
using System.Text;
using usb;

namespace commands
{
    namespace reactivecommands
    {
        public class ReadValueCommand : ReactiveFullCommand
        {
            public ReadValueCommand()
            {

            }

            public override void executeOnPort1(System.IO.Ports.SerialPort port1)
            {             
                port1.Write(StringToHexParser.parse("M0\r"), 0, 3);
            }

            public override void executeOnPort2(System.IO.Ports.SerialPort port2)
            {
                port2.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);
            }

            public override void react(char[] answerData1, char[] answerData2)
            {
                Console.Write(answerData1);
                Console.Write("\n");
                Console.Write(answerData2);
                Console.Write("\n");
                Console.Write("\n");
            }

            public override bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}