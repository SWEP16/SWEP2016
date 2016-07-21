using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class StartAccumulation : ReactiveCommand
        {            
            public StartAccumulation()
            {
            }

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                Console.Write("excute startAcc ");
                port1.Write(new byte[] { 0x41, 0x53, 0x0D }, 0, 3);
                port2.Write(new byte[] { 0x4D, 0x31, 0x0D }, 0, 3);//dummy Befehl (nur ein Laser in Verwendung)
            }

            public void react(char[] answerData1, char[] answerData2)
            {
                Console.WriteLine("answer StartAcc: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AS")
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