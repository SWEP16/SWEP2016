using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    class RepeatingAccuracyMeasurement {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public RepeatingAccuracyMeasurement(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
