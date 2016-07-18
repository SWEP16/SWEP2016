using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class TriggerValueCommand : ReactiveCommand
        {
            private RepeatingAccuracyMeasurementSeries series;

            public TriggerValueCommand(RepeatingAccuracyMeasurementSeries series)
            {
                this.series = series;
            }

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                port1.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);
                port2.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);

            }

            public void react(char[] answerData1, char[] answerData2)
            {
                string answString1 = new string(answerData1);
                answString1 = answString1.Replace(',', ';');
                answString1 = answString1.Replace('.', ',');
                string[] answStrArray1 = answString1.Split(';');

                string answString2 = new string(answerData2);
                answString2 = answString2.Replace(',', ';');
                answString2 = answString2.Replace('.', ',');
                string[] answStrArray2 = answString2.Split(';');

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

                int counter = 0;
                for (int i=0; i<4; i++)
                {
                    try
                    {
                        values[counter] = Double.Parse(possibleAnswers[i]);
                        counter++;
                    }
                    catch(Exception e){}
                }

                if (counter != 3) throw new Exception("Nich alle Laser sind in der Reichweite zur Messung. Abstand verändern!");

                this.series.addMeasurement(new RepeatingAccuracyMeasurement(values[0], values[1], values[2]));
            }
            

            public bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}