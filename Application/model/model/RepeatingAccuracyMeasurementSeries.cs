using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    class RepeatingAccuracyMeasurementSeries : MeasurementSeries{
        private List<RepeatingAccuracyMeasurement> measurements;

        public RepeatingAccuracyMeasurementSeries() {
            this.measurements = new List<RepeatingAccuracyMeasurement>();
        }
        public void addMeasurement(RepeatingAccuracyMeasurement measurement) {
            this.measurements.Add(measurement);
        }

        public RepeatingAccuracyMeasurement getMeasurement(int index) {
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