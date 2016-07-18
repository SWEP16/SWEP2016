using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class StopAccumulation : ReactiveCommand
        {
            public StopAccumulation()
            {
            }

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                Console.Write("excute stopAcc ");
                port1.Write(new byte[] { 0x41, 0x50, 0x0D }, 0, 3);
                port2.Write(new byte[] { 0x41, 0x50, 0x0D }, 0, 3);
            }

            public void react(char[] answerData1, char[] answerData2)
            {
                Console.WriteLine("answer StopAcc: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AP")
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