using SensorGUI.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using usb;


namespace commands {
    namespace reactivecommands {
        public class AutoZeroOnCommand : ReactiveFullCommand {
            public AutoZeroOnCommand() {

            }

            public override void executeOnPort1(System.IO.Ports.SerialPort port1) {
                String command = "V0\r";
                byte[] commandByteArray = StringToHexParser.parse(command);
                port1.Write(commandByteArray, 0, commandByteArray.Length);
                Console.WriteLine("EXECUTE AUTO ZERO ON COMMAND on Port 1");
            }

            public override void executeOnPort2(System.IO.Ports.SerialPort port2) {
                String command = "V0\r";
                byte[] commandByteArray = StringToHexParser.parse(command);
                port2.Write(commandByteArray, 0, commandByteArray.Length);
                Console.WriteLine("EXECUTE AUTO ZERO ON COMMAND on Port 2");
            }

            public override void react(char[] answerData1, char[] answerData2, MainWindowViewModel viewModel) {
                Console.WriteLine("REACT AutoZeroOnCommand");
                Console.WriteLine(answerData1);
                Console.WriteLine(answerData2);
            }

            public override bool isCorrectAnswerFormat(char[] answerData) {
                return true;
            }
        }
    }
}