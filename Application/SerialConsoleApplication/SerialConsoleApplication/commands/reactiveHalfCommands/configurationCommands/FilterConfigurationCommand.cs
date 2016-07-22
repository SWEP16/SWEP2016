using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands {
    namespace reactivecommands {

        class FilterConfigurationCommand : ReactiveHalfCommand{
            public int OUTNr { get; set; }
            public int filtermodus { get; set; }
            public int anzahlMittelungen { get; set; }
            public FilterConfigurationCommand(int OUTNr, int anzahlMittelungen, int filtermodus) {
                this.OUTNr = OUTNr;
                // in diesem Fall immer 0
                this.filtermodus = filtermodus;
                this.anzahlMittelungen = anzahlMittelungen;
            }

            public override void execute(System.IO.Ports.SerialPort port) {
                Console.Write("excute Filter Config ");
                string command = "SW,OC," + OUTNr.ToString() + "," + filtermodus.ToString() + "," + anzahlMittelungen.ToString() + "\r";
                port.Write(usb.StringToHexParser.parse(command), 0, command.Length);
            }

            public override void react(char[] answerData1) {
                Console.WriteLine("answer Filter Config: " + new String(answerData1));
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