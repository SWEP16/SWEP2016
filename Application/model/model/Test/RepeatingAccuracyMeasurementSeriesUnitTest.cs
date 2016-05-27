using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Test {
    class RepeatingAccuracyMeasurementSeriesUnitTest : UnitTest {
        public override bool test() {
            RepeatingAccuracyMeasurement measurement1 = new RepeatingAccuracyMeasurement(1.0, -2.3, 0.0);
            RepeatingAccuracyMeasurement measurement2 = new RepeatingAccuracyMeasurement(5.0, 1.3, 6.3);
            RepeatingAccuracyMeasurement measurement3 = new RepeatingAccuracyMeasurement(-8.3, 6.9, 6.9);

            RepeatingAccuracyMeasurementSeries series = new RepeatingAccuracyMeasurementSeries();

            series.addMeasurement(measurement1);
            series.addMeasurement(measurement2);
            series.addMeasurement(measurement3);

            if (series.getMeasurement(0).x != 1.0) return false;
            if (series.getMeasurement(1).z != 6.3) return false;
            if (series.getMeasurement(2).x != -8.3) return false;
            if (series.getMeasurement(2).y != 6.9) return false;

            if (series.getMeasurementsLength() != 3.0) return false;

            try {
                series.getMeasurement(3); // should throw Exception, because index 3 doesnt exist
                return false; // Exception should be thrown
            }
            catch (MeasurementDoesntExistException e){
                // Right Exception was thrown
            }
            catch (Exception e){
                return false; // Wrong Exception was thrown
            }
        return true;
        }
    }
}
