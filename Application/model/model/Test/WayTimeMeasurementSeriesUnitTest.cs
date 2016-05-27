using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Test {
    class WayTimeMeasurementSeriesUnitTest : UnitTest {
        public override bool test() {
            var values1 = new List<Tuple<double, double>>();
            var values2 = new List<Tuple<double, double>>();
            var values3 = new List<Tuple<double, double>>();

            values1.Add(Tuple.Create(1.0, 7.3));
            values1.Add(Tuple.Create(1.6, 8.2));
            values1.Add(Tuple.Create(2.5, 6.3));

            values2.Add(Tuple.Create(5.2, -7.0));
            values2.Add(Tuple.Create(1.0, -8.6));
            values2.Add(Tuple.Create(0.0, 2.3));

            values3.Add(Tuple.Create(-2.2, -7.0));
            values3.Add(Tuple.Create(-3.6, -8.6));
            values3.Add(Tuple.Create(-4.5, 2.3));

            WayTimeMeasurement measurement1 = new WayTimeMeasurement(values1);
            WayTimeMeasurement measurement2 = new WayTimeMeasurement(values2);
            WayTimeMeasurement measurement3 = new WayTimeMeasurement(values3);

            WayTimeMeasurementSeries series = new WayTimeMeasurementSeries();

            series.addMeasurement(measurement1);
            series.addMeasurement(measurement2);
            series.addMeasurement(measurement3);


            if (series.getMeasurement(0).getValue(0).Item1 != 1.0) return false;
            if (series.getMeasurement(0).getValue(0).Item2 != 7.3) return false;
            if (series.getMeasurement(0).getValue(1).Item1 != 1.6) return false;
            
            if (series.getMeasurement(1).getValue(0).Item2 != -7.0) return false;
            if (series.getMeasurement(1).getValue(1).Item1 != 1.0) return false;
            if (series.getMeasurement(1).getValue(2).Item1 != 0.0) return false;
          
            if (series.getMeasurement(2).getValue(0).Item1 != -2.2) return false;
            if (series.getMeasurement(2).getValue(1).Item2 != -8.6) return false;
            if (series.getMeasurement(2).getValue(2).Item1 != -4.5) return false;

            if (series.getMeasurementsLength() != 3) return false;

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
