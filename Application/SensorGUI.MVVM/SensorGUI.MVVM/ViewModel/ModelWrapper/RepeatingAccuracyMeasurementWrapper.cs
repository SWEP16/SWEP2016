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

        public float Value1 {
            get
            {
                return Math.Abs((float)this.originalRepeatingAccuracyMeasurement.value1);
            }
            set { }
        }
        public float Value2
        {
            get
            {
                return Math.Abs((float)this.originalRepeatingAccuracyMeasurement.value2);
            }
            set { }
        }
        public float Value3
        {
            get
            {
                return Math.Abs((float)this.originalRepeatingAccuracyMeasurement.value3);
            }
            set { }
        }
    }
}
