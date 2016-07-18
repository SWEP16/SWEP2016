using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class InitAccumulation : ReactiveCommand
        {
            public InitAccumulation()
            {                
            }

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                Console.Write("excute initAcc ");
                port1.Write(new byte[] { 0x41, 0x51, 0x0D }, 0, 3);
                port2.Write(new byte[] { 0x41, 0x51, 0x0D }, 0, 3);
            }

            public void react(char[] answerData1, char[] answerData2)
            {
                Console.WriteLine("answer initAcc: "+ new String(answerData1));
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