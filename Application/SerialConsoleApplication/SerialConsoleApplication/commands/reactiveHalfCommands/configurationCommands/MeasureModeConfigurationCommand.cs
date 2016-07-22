using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands {
    namespace reactivecommands {

        class MeasureModeConfigurationCommand : ReactiveHalfCommand {
            public int OUTNr { get; set; }
            public int messmodus { get; set; }
            public MeasureModeConfigurationCommand(int OUTNr, int messmodus) {
                this.OUTNr = OUTNr;
                // in diesem Fall immer 0
                this.messmodus = 0;
            }

            public override void execute(System.IO.Ports.SerialPort port) {
                Console.Write("excute MeasureMode Config ");
                string command = "SW,OD," + OUTNr.ToString() + "," + messmodus.ToString() + "/r";
                port.Write(usb.StringToHexParser.parse(command), 0, command.Length);
            }

            public override void react(char[] answerData1) {
                Console.WriteLine("answer MeasureMode Config: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AO")
                {
                    //mach iwas fehlerl ER oderso
                }
                */
            }

            public override bool isCorrectAnswerFormat(char[] answerData) {
                return true;
            }
        }
    }
}