using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    class MeasurementSeriesCollection {
        private List<MeasurementSeries> measurementSeries = new List<MeasurementSeries>();
        private List<Observer> observers = new List<Observer>();

        public MeasurementSeriesCollection() {

        }
        public void addMeasurementSeries(MeasurementSeries measurementSeries) {
            this.measurementSeries.Add(measurementSeries);
        }

        public MeasurementSeries getMeasurementSeries(int measurementSeriesIndex) {
            return this.measurementSeries.ElementAt(measurementSeriesIndex);
        }

        public int getMeasurementSeriesLength() {
            return this.measurementSeries.Count();
        }

        public void removeMeasurementSeries(int measurementSeriesIndex) {
            this.measurementSeries.RemoveAt(measurementSeriesIndex);
        }
    }
}
