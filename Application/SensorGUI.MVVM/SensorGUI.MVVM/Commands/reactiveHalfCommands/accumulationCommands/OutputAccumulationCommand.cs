using System;
using System.Collections.Generic;
using System.Text;
using model;

namespace commands {
    namespace reactivecommands {
        public class OutputAccumulationCommand : ReactiveHalfCommand {
            private MeasurementSeriesCollection seriesCollection;

            public OutputAccumulationCommand(MeasurementSeriesCollection seriesCollection) {
                this.seriesCollection = seriesCollection;
            }

            public override void execute(System.IO.Ports.SerialPort port) {
                Console.Write("excute outputAcc ");
                port.Write(new byte[] { 0x41, 0x4f, 0x2c, 0x31, 0x0D }, 0, 5);
            }

            public override void react(char[] answerData) {
                Console.WriteLine("answer output");
                Console.WriteLine("answer OutputAcc: " + new String(answerData));
                /*
                if(answStrArray1[0] != "AO")
                {
                    //mach iwas fehlerl ER oderso
                }
                */

                string answString1 = new string(answerData);
                answString1 = answString1.Replace(',', ';');
                answString1 = answString1.Replace('.', ',');
                string[] answStrArray1 = answString1.Split(';');

                List<Tuple<double, double>> values = new List<Tuple<double, double>>();

                for(int i = 0; i < answStrArray1.Length - 1; i++) {
                    try {
                        Tuple<double, double> tuple = new Tuple<double, double>(0, Double.Parse(answStrArray1[i + 1]));
                        values.Add(tuple);
                    }
                    catch(Exception e) {
                        Tuple<double, double> tuple = new Tuple<double, double>(0, Double.PositiveInfinity);
                        values.Add(tuple);
                    }
                }

                WayTimeMeasurementSeries wayTimeMeasurementSeries = new WayTimeMeasurementSeries("Neuer Messvorgang");
                wayTimeMeasurementSeries.setMeasurements(values);
                this.seriesCollection.addMeasurementSeries(wayTimeMeasurementSeries);
            }

            public override bool isCorrectAnswerFormat(char[] answerData) {
                return true;
            }
        }
    }
}