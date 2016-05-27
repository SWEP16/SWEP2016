using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Test {
    class WayTimeMeasurementUnitTest : UnitTest {
        public override bool test() {
            var values = new List<Tuple<double, double>>();
            values.Add(Tuple.Create(32.2, 12.3));
            values.Add(Tuple.Create(22.2, 73.3));

            WayTimeMeasurement measurement= new WayTimeMeasurement(values);

            if (measurement.getValuesLegth() != 2) {
                return false;
            }
            if(measurement.getValue(0).Item1 != 32.2) {
                return false;
            }
            if (measurement.getValue(0).Item2 != 12.3) {
                return false;
            }

            if (measurement.getValue(1).Item1 != 22.2) {
                return false;
            }
            if (measurement.getValue(1).Item2 != 73.3) {
                return false;
            }

            return true;
        }
    }
}
