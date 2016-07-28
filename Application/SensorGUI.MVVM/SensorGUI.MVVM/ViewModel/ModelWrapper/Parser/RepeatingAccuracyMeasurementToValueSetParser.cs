using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    public class RepeatingAccuracyMeasurementToValueSetParser 
    {
        public static ObservableCollection<ValueSet> parse (RepeatingAccuracyMeasurementSeriesWrapper series)  
        {
            ObservableCollection<ValueSet> valueSets = new ObservableCollection<ValueSet>();

            for (int i=0; i < series.Measurements.Count; i++)
            {
                ValueSet valueSet = new ValueSet();
                valueSet.Value1 = (float)(series.Measurements[i].Value1);
                valueSet.Value2 = (float)(series.Measurements[i].Value2);
                valueSet.Value3 = (float)(series.Measurements[i].Value3);
                valueSets.Add(valueSet);
            }

            return valueSets;
        }
    }
}
