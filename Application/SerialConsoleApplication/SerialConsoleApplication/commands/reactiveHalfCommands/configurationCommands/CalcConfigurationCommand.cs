using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands
{
    namespace reactivecommands
    {
        public class CalcConfigurationCommand : ReactiveHalfCommand
        {
            public CalcConfigurationCommand()
            {
            }

            public override void execute(System.IO.Ports.SerialPort port)
            {
                Console.Write("excute Calc Config ");
                port.Write(new byte[] { 0x41, 0x51, 0x0D }, 0, 3);
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