using SensorGUI.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands {
    namespace reactivecommands {

        class AmountOfDataConfigurationCommand : ReactiveHalfCommand {
            public int OUTNr { get; set; }
            public int dspoints { get; set; }
            public int dsfreq { get; set; }
            public AmountOfDataConfigurationCommand(int OUTNr, int dspoints, int dsfreq) {
                this.OUTNr = OUTNr;
                this.dspoints = dspoints;
                this.dsfreq = dsfreq;
            }

            public override void execute(System.IO.Ports.SerialPort port) {
                Console.Write("excute AmountOfData Config ");
                string command = "SW,CI," + OUTNr.ToString() + "," + dspoints.ToString() + "," + dsfreq.ToString() + "\r";
                port.Write(usb.StringToHexParser.parse(command), 0, command.Length);
            }

            public override void react(char[] answerData1, MainWindowViewModel viewModel) {
                Console.WriteLine("answer AmountOfData Config: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AO")
                {
                    //mach iwas fehlerl ER oderso
                }
                */
                viewModel.update();
            }

            public override bool isCorrectAnswerFormat(char[] answerData) {
                return true;
            }
        }
    }
}