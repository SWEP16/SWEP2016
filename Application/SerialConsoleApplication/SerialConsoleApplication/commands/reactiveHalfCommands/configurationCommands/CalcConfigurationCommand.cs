using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands
{
    namespace reactivecommands
    {
        //Berechnungsverfahren
        public class CalcConfigurationCommand : ReactiveHalfCommand
        {
            public int OUTNr { get; set; }
            public int berechnungsmethode { get; set; }
            public int berechnungWellenform { get; set; }

            public CalcConfigurationCommand(int OUTNr, int berechnungsmethode)
            {
                this.OUTNr = OUTNr;
                this.berechnungsmethode = berechnungsmethode;
                // in diesem Fall immer 0
                this.berechnungWellenform = 0;
            }

            public override void execute(System.IO.Ports.SerialPort port)
            {
                Console.Write("excute Calc Config ");
                string command = "SW,OA," + OUTNr.ToString() + "," + berechnungsmethode.ToString() + "," + berechnungWellenform.ToString() + "/r";
                port.Write(usb.StringToHexParser.parse(command), 0, command.Length);
            }

            public override void react(char[] answerData1)
            {
                Console.WriteLine("answer Calc Config: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AO")
                {
                    //mach iwas fehlerl ER oderso
                }
                */
            }

            public override bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}