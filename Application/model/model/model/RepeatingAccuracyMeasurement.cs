using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    class RepeatingAccuracyMeasurement {
        public double value1 { get; set; }
        public double value2 { get; set; }
        public double value3 { get; set; }

        public RepeatingAccuracyMeasurement(double value1, double value2, double value3) {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
        }
    }
}
