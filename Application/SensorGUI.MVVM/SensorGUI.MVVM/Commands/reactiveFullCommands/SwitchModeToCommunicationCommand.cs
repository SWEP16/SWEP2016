using System;
using System.Collections.Generic;
using System.Text;
using usb;


namespace commands
{
    namespace reactivecommands
    {
        public class SwitchModeToCommunicationCommand : ReactiveFullCommand
        {
            public SwitchModeToCommunicationCommand()
            {

            }

            public override void executeOnPort1(System.IO.Ports.SerialPort port1)
            {
                Console.WriteLine("Execute Switch Mode to Communication (Port 1)");
                String command = "Q0\r";
                byte[] commandByteArray = StringToHexParser.parse(command);
                port1.Write(commandByteArray, 0, commandByteArray.Length);
            }

            public override void executeOnPort2(System.IO.Ports.SerialPort port2)
            {
                Console.WriteLine("Execute Switch Mode to Communication (Port 2)");
                String command = "Q0\r";
                byte[] commandByteArray = StringToHexParser.parse(command);
                port2.Write(commandByteArray, 0, commandByteArray.Length);
            }

            public override void react(char[] answerData1, char[] answerData2)
            {
                Console.WriteLine(answerData1);
                Console.WriteLine(answerData2);
            }

            public override bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}