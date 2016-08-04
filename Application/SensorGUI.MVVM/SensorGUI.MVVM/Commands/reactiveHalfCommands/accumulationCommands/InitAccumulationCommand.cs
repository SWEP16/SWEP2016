using System;
using System.Collections.Generic;
using System.Text;
using model;
using SensorGUI.MVVM.ViewModel;
using SensorGUI.MVVM;

namespace commands {
    namespace reactivecommands {
        public class InitAccumulationCommand : ReactiveHalfCommand {
            public InitAccumulationCommand() {
            }

            public override void execute(System.IO.Ports.SerialPort port) {
                Console.Write("excute initAcc ");
                port.Write(new byte[] { 0x41, 0x51, 0x0D }, 0, 3);
            }

            public override void react(char[] answerData, MainWindowViewModel viewModel) {
                Console.WriteLine("answer initAcc: " + new String(answerData));
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