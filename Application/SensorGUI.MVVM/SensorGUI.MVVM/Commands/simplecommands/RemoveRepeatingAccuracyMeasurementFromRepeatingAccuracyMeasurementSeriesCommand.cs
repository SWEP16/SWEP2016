using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace commands 
{
    namespace simplecommands 
    {
        public class RemoveRepeatingAccuracyMeasurementFromLastRepeatingAccuracyMeasurementSeriesCommand : SimpleCommand 
        {
            private MeasurementSeriesCollection measurementSeriesCollection;
            private int index;

            public RemoveRepeatingAccuracyMeasurementFromLastRepeatingAccuracyMeasurementSeriesCommand(MeasurementSeriesCollection measurementSeriesCollection, int index) 
            {
                this.measurementSeriesCollection = measurementSeriesCollection;
            }

            public void execute() 
            {
                int lastIndex = this.measurementSeriesCollection.getMeasurementSeriesLength() - 1;
                RepeatingAccuracyMeasurementSeries repeatingAccuracyMeasurementSeries = (RepeatingAccuracyMeasurementSeries)(this.measurementSeriesCollection.getMeasurementSeries(lastIndex));
                repeatingAccuracyMeasurementSeries.removeMeasurement(this.index);
            }
        }
    }
}
