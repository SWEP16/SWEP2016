using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class StopAccumulation : ReactiveHalfCommand
        {
            public StopAccumulation()
            {
            }

            public override void execute(System.IO.Ports.SerialPort port)
            {
                Console.Write("excute stopAcc ");
                port.Write(new byte[] { 0x41, 0x50, 0x0D }, 0, 3);
            }

            public override void react(char[] answerData)
            {
                Console.WriteLine("answer StopAcc: " + new String(answerData));
                /*
                if(answStrArray1[0] != "AP")
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