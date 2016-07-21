using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class InitAccumulation : ReactiveHalfCommand
        {
            public InitAccumulation()
            {                
            }

            public override void execute(System.IO.Ports.SerialPort port)
            {
                Console.Write("excute initAcc ");
                port.Write(new byte[] { 0x41, 0x51, 0x0D }, 0, 3);
            }

            public override void react(char[] answerData1)
            {
                Console.WriteLine("answer initAcc: "+ new String(answerData1));
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