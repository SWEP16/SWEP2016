using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class ValueSet {

        private RepeatingAccuracyMeasurement orginalRepeatingAccuracyMeasurement;

        public ValueSet(RepeatingAccuracyMeasurement orginalRepeatingMeasurement) 
        {
            this.orginalRepeatingAccuracyMeasurement = orginalRepeatingMeasurement;
        }

        private float _Value1;
        private float _Value2;
        private float _Value3;

        public float Value1
        {
            get
            {
                return (float)(this.orginalRepeatingAccuracyMeasurement.value1);
            }
        }

        public float Value2
        {
            get
            {
                return (float)(this.orginalRepeatingAccuracyMeasurement.value1);
            }
        }
        public float Value3
        {
            get
            {
                return (float)(this.orginalRepeatingAccuracyMeasurement.value1);
            }
        }

    }
}
