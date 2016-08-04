using System;
using System.Collections.Generic;
using System.Text;
using model;
using SensorGUI.MVVM;

namespace commands
{
    namespace reactivecommands
    {
        public class TriggerValueCommand : ReactiveFullCommand
        {
            private MeasurementSeriesCollection measurementSeriesCollection;

            public TriggerValueCommand(MeasurementSeriesCollection measurementSeriesCollection)
            {
                this.measurementSeriesCollection = measurementSeriesCollection;
            }

            public override void executeOnPort1(System.IO.Ports.SerialPort port1)
            {
                port1.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);
            }

            public override void executeOnPort2(System.IO.Ports.SerialPort port2)
            {
                port2.Write(new byte[] { 0x4D, 0x30, 0x0D }, 0, 3);
            }

            public override void react(char[] answerData1, char[] answerData2, MainWindowViewModel viewModel)
            {
                Console.WriteLine(answerData1);
                Console.WriteLine(answerData2);

                String answString1 = new String(answerData1);
                answString1 = answString1.Replace(',', ';');
                answString1 = answString1.Replace('.', ',');
                String[] answStrArray1 = answString1.Split(';');

                String answString2 = new String(answerData2);
                answString2 = answString2.Replace(',', ';');
                answString2 = answString2.Replace('.', ',');
                String[] answStrArray2 = answString2.Split(';');

                double[] values = new double[3];

                String[] possibleAnswers = new String[4];
                possibleAnswers[0] = answStrArray1[1];
                possibleAnswers[1] = answStrArray1[2];
                possibleAnswers[2] = answStrArray2[1];
                possibleAnswers[3] = answStrArray2[2];
                
                int counter = 0;
                for (int i=0; i<3; i++)
                {
                    double result = 0;
                    if(Double.TryParse(possibleAnswers[i], out result)) 
                    {
                        values[i] = result;
                        counter++;
                    } else {
                        values[i] = Double.PositiveInfinity;
                    }
                }

                int measurementSeriesCollectionLength = this.measurementSeriesCollection.getMeasurementSeriesLength();
                MeasurementSeries series = this.measurementSeriesCollection.getMeasurementSeries(measurementSeriesCollectionLength - 1);


                if(series is RepeatingAccuracyMeasurementSeries)
                {
                    RepeatingAccuracyMeasurementSeries repeatingAccuracyMeasurementSeries = (RepeatingAccuracyMeasurementSeries)(series);
                    repeatingAccuracyMeasurementSeries.addMeasurement(new RepeatingAccuracyMeasurement(values[0], values[1], values[2]));
                }
                else
                {
                    throw new Exception("Aktuelle Messreihe ist keine Genauigkeitsmessung.");
                }

                

                if(counter != 3) 
                {
                    viewModel.update();
                    
                    throw new Exception("Der Messsenor liefert keinen gültigen Wert. Mögliche Ursachen dafür können beispielsweise sein, " +
                       "dass der Laser nicht ordnungsgemäß angeschlossen ist oder das Messobjekt sich außerhalb der Reichweite befindet. ");
                }

                viewModel.update();
            }
            

            public override bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}