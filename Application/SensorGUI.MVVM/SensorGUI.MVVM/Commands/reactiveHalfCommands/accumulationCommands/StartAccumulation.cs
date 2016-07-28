using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class StartAccumulation : ReactiveHalfCommand
        {            
            public StartAccumulation()
            {
            }

            public override void execute(System.IO.Ports.SerialPort port)
            {
                Console.Write("excute startAcc ");
                port.Write(new byte[] { 0x41, 0x53, 0x0D }, 0, 3);
            }

            public override void react(char[] answerData)
            {
                Console.WriteLine("answer StartAcc: " + new String(answerData));
                /*
                if(answStrArray1[0] != "AS")
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