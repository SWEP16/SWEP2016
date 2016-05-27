using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    class WayTimeMeasurementSeries : MeasurementSeries{
        private List<WayTimeMeasurement> measurements;

        public WayTimeMeasurementSeries() {
            measurements = new List<WayTimeMeasurement>();
        }
        public void addMeasurement(WayTimeMeasurement measurement) {
            this.measurements.Add(measurement);
        }

        public WayTimeMeasurement getMeasurement(int index) {
            if(index >= this.getMeasurementsLength()) {
                throw new MeasurementDoesntExistException();
                //return 0;
            }
            else {
                return this.measurements.ElementAt(index);
            }
        }

        public override int getMeasurementsLength() {
            return this.measurements.Count();
        }
        
    }
}
