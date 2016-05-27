using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Test {
    class RepeatingAccuracyMeasurementUnitTest : UnitTest {
        public override bool test() {
            RepeatingAccuracyMeasurement measurement = new RepeatingAccuracyMeasurement(32, 12.73, -3.2);
  
            if (measurement.x != 32) return false;
            if (measurement.y != 12.73) return false;
            if (measurement.z != -3.2) return false;

            return true;
        }
    }
}
