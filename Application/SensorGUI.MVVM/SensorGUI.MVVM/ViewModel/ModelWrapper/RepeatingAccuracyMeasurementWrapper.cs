using model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class RepeatingAccuracyMeasurementWrapper 
    {
        private RepeatingAccuracyMeasurement originalRepeatingAccuracyMeasurement;

        public RepeatingAccuracyMeasurementWrapper(RepeatingAccuracyMeasurement original) 
        {
            this.originalRepeatingAccuracyMeasurement = original;
        }

        public string Value1 {
            get
            {
                double value = this.originalRepeatingAccuracyMeasurement.value1;
                if(value == double.PositiveInfinity) 
                {
                    return "FFFFFF";
                }
                else 
                {
                    return value.ToString();
                }
            }
            set { }
        }
        public string Value2
        {
            get
            {
                double value = this.originalRepeatingAccuracyMeasurement.value2;
                if(value == double.PositiveInfinity) {
                    return "FFFFFF";
                }
                else {
                    return value.ToString();
                }
            }
            set { }
        }
        public string Value3
        {
            get
            {
                double value = this.originalRepeatingAccuracyMeasurement.value3;
                if(value == double.PositiveInfinity) {
                    return "FFFFFF";
                }
                else {
                    return value.ToString();
                }
            }
            set { }
        }
    }
}
