using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands
{
    namespace reactivecommands
    {
        public class OutputAccumulation : ReactiveCommand
        {
            private WayTimeMeasurementSeries series;

            public OutputAccumulation(WayTimeMeasurementSeries series)
            {
                this.series = series;
            }

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                Console.Write("excute outputAcc ");
                port1.Write(new byte[] { 0x41, 0x4f, 0x2c, 0x31, 0x0D }, 0, 5);
                port2.Write(new byte[] { 0x4D, 0x31, 0x0D }, 0, 3);//dummy Befehl (nur ein Laser in Verwendung)
            }

            public void react(char[] answerData1, char[] answerData2)
            {
                Console.WriteLine("answer output");
                Console.WriteLine("answer OutputAcc: " + new String(answerData1));
                /*
                if(answStrArray1[0] != "AO")
                {
                    //mach iwas fehlerl ER oderso
                }
                */

                string answString1 = new string(answerData1);
                answString1 = answString1.Replace(',', ';');
                answString1 = answString1.Replace('.', ',');
                string[] answStrArray1 = answString1.Split(';');

                List<Tuple<double, double>> values = new List<Tuple<double, double>>();

                for (int i = 0; i < answStrArray1.Length - 1; i++)
                {
                    try
                    {
                        Tuple<double, double> tuple = new Tuple<double, double>(0, Double.Parse(answStrArray1[i + 1]));
                        values.Add(tuple);
                    }
                    catch (Exception e) {
                        Tuple<double, double> tuple = new Tuple<double, double>(0, Double.PositiveInfinity);
                        values.Add(tuple);
                    }
                }

                this.series.addMeasurement(new WayTimeMeasurement(values));
            }

            public bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}