using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace SensorGUI.MVVM.ViewModel 
{
    class ModelToWrappedModelParser 
    {
        public MeasurementSeriesWrapper parse(MeasurementSeries measurementSeries) 
        {
            if (measurementSeries is RepeatingAccuracyMeasurementSeries)
            {
                RepeatingAccuracyMeasurementSeries series = (RepeatingAccuracyMeasurementSeries)measurementSeries;
                MeasurementSeriesWrapper wrappedSeries = new MeasurementSeriesWrapper(series);
                
                for (int i = 0; i < measurementSeries.getMeasurementsLength(); i++)
                {
                    RepeatingAccuracyMeasurement measurement = series.getMeasurement(i);
                    ValueSet wrappedRepeatingAccuracyMeasurement = new ValueSet(measurement);
                    wrappedSeries.addRepeatingAccuracyMeasurement(wrappedRepeatingAccuracyMeasurement);
                }

                return wrappedSeries;
            }

            return null;
        }
    }
}
