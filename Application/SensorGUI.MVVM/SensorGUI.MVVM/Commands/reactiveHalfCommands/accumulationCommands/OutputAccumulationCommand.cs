using System;
using System.Collections.Generic;
using System.Text;
using model;
using SensorGUI.MVVM;

namespace commands {
    namespace reactivecommands {
        public class OutputAccumulationCommand : ReactiveHalfCommand {
            private MeasurementSeriesCollection seriesCollection;
            private double TotalTime;

            public OutputAccumulationCommand(MeasurementSeriesCollection seriesCollection, double TotalTime) {
                this.seriesCollection = seriesCollection;
                this.TotalTime = TotalTime;
            }

            public override void execute(System.IO.Ports.SerialPort port) {
                Console.Write("excute outputAcc ");
                port.Write(new byte[] { 0x41, 0x4f, 0x2c, 0x31, 0x0D }, 0, 5);
            }

            public override void react(char[] answerData, MainWindowViewModel viewModel) {
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
                        Tuple<double, double> tuple = new Tuple<double, double> (((double)(i+1) / answStrArray1.Length) * this.TotalTime, Double.Parse(answStrArray1[i + 1]));
                        values.Add(tuple);
                    }
                    catch(Exception e) {
                        Tuple<double, double> tuple;

                        if(i == 0) 
                        {
                            tuple = new Tuple<double, double>(((double)(i + 1) / answStrArray1.Length) * this.TotalTime, 0);
                        }
                        else 
                        {
                           tuple = new Tuple<double, double>(((double)(i + 1) / answStrArray1.Length) * this.TotalTime, values[i - 1].Item2);
                        }

                        values.Add(tuple);
                    }
                }

                int lastIndex = this.seriesCollection.getMeasurementSeriesLength() - 1;
                MeasurementSeries lastMeasurementSeries = this.seriesCollection.getMeasurementSeries(lastIndex);

                if(lastMeasurementSeries is WayTimeMeasurementSeries) 
                {
                    WayTimeMeasurementSeries wayTimeMeasurementSeries = (WayTimeMeasurementSeries)lastMeasurementSeries;
                    wayTimeMeasurementSeries.setMeasurements(values);
                }
                else 
                {
                    throw new Exception("Expected WayTimeMeasurement Series for Output Accumulation Command!");
                }
                viewModel.update();
            }

            public override bool isCorrectAnswerFormat(char[] answerData) {
                return true;
            }
        }
    }
}