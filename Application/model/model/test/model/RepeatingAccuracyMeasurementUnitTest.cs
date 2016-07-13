using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using model;

namespace test.model
{
    class RepeatingAccuracyMeasurementUnitTest : UnitTest {
        public override bool test() {
            RepeatingAccuracyMeasurement measurement = new RepeatingAccuracyMeasurement(32, 12.73, -3.2);
  
            if (measurement.value1 != 32) return false;
            if (measurement.value2 != 12.73) return false;
            if (measurement.value3 != -3.2) return false;

            return true;
        }
    }
}
