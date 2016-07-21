using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands
{
    namespace reactivecommands
    {
        public class CalcConfigurationCommand : ReactiveCommand
        {
            public CalcConfigurationCommand()
            {
            }

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                Console.Write("excute Calc Config ");
                port1.Write(new byte[] { 0x41, 0x51, 0x0D }, 0, 3);
                port2.Write(new byte[] { 0x4D, 0x31, 0x0D }, 0, 3);//dummy Befehl (nur ein Laser in Verwendung)
            }

            public void react(char[] answerData1, char[] answerData2)
            {
                Console.WriteLine("answer Calc Config: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AO")
                {
                    //mach iwas fehlerl ER oderso
                }
                */
            }

            public bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}