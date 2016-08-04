using model;
using SensorGUI.MVVM;
using SensorGUI.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using usb;

namespace commands {
    namespace reactivecommands {
        public class ReadValueCommand : ReactiveFullCommand {
            

            public ReadValueCommand() 
            {

            }

            public override void executeOnPort1(System.IO.Ports.SerialPort port1) {
                port1.Write(StringToHexParser.parse("M0\r"), 0, 3);
            }

            public override void executeOnPort2(System.IO.Ports.SerialPort port2) {
                port2.Write(StringToHexParser.parse("M0\r"), 0, 3);
            }

            public override void react(char[] answerData1, char[] answerData2, MainWindowViewModel viewModel) {
                String answString1 = new String(answerData1);
                answString1 = answString1.Replace(',', ';');
                answString1 = answString1.Replace('.', ',');
                String[] answStrArray1 = answString1.Split(';');

                String answString2 = new String(answerData2);
                answString2 = answString2.Replace(',', ';');
                answString2 = answString2.Replace('.', ',');
                String[] answStrArray2 = answString2.Split(';');

                double[] values = new double[3];
                /*
                if(answStrArray1[0] != "M0")
                {
                    //mach iwas fehlerl ER oderso
                }
                */

                String[] possibleAnswers = new String[4];
                possibleAnswers[0] = answStrArray1[1];
                possibleAnswers[1] = answStrArray1[2];
                possibleAnswers[2] = answStrArray2[1];
                possibleAnswers[3] = answStrArray2[2];

                Console.WriteLine(answerData1);
                Console.WriteLine(answerData2);

                int counter = 0;
                for(int i = 0; i < 3; i++) {

                    double result = 0;
                    if(Double.TryParse(possibleAnswers[i], out result)) 
                    {
                        values[i] = result;
                        counter++;
                    }
                    else
                    {
                        values[i] = Double.PositiveInfinity;
                    }
                }
                
                viewModel.UpdateLiveValues(new RepeatingAccuracyMeasurement(values[0], values[1], values[2]));
            }

            public override bool isCorrectAnswerFormat(char[] answerData) {
                return true;
            }
        }
    }
}