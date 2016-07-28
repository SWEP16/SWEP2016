using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    public class WayTimeMeasurementSeries : MeasurementSeries{
        private List<Tuple<double, double>> measurements;

        public WayTimeMeasurementSeries(string name) : base(name) {
            this.measurements = new List<Tuple<double, double>>();
        }
        public void addMeasurement(Tuple<double, double> measurement) {
            this.measurements.Add(measurement);
        }

        public void setMeasurements(List<Tuple<double, double>> measurements) 
        {
            this.measurements = measurements;
        }

        public Tuple<double, double> getMeasurement(int index) {
            if(index >= this.getMeasurementsLength()) {
                throw new MeasurementDoesntExistException();
                //return 0;
            }
            else 
            {
                Console.WriteLine(index);

                return this.measurements.ElementAt(index);
            }
        }

        public override int getMeasurementsLength() {
            return this.measurements.Count();
        }        
    }
}
