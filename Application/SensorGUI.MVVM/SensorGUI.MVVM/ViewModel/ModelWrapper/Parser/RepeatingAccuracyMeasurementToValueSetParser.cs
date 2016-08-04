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

                float result;
                if(float.TryParse(series.Measurements[i].Value1, out result))
                {
                    valueSet.Value1 = result;
                }
                else 
                {
                    valueSet.Value1 = float.PositiveInfinity;
                }

                if(float.TryParse(series.Measurements[i].Value2, out result)) {
                    valueSet.Value2 = result;
                } else {
                    valueSet.Value2 = float.PositiveInfinity;
                }

                if(float.TryParse(series.Measurements[i].Value3, out result)) {
                    valueSet.Value3 = result;
                } else {
                    valueSet.Value3 = float.PositiveInfinity;
                }

                valueSets.Add(valueSet);
            }

            return valueSets;
        }
    }
}
