using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class RepeatingAccuracyMeasurementSeriesWrapper : MeasurementSeriesWrapper{

       // private RepeatingAccuracyMeasurementSeries originalRepeatingAccuracyMeasurementSeriesWrapper;

        public ObservableCollection<RepeatingAccuracyMeasurementWrapper> Measurements { get; set; }

        public RepeatingAccuracyMeasurementSeriesWrapper(RepeatingAccuracyMeasurementSeries original) : base(original) {
            this.Measurements = new ObservableCollection<RepeatingAccuracyMeasurementWrapper>();
        }

        public void addRepeatingAccuracyMeasurement(RepeatingAccuracyMeasurementWrapper measurementWrapper) {
            this.Measurements.Add(measurementWrapper);
        }
    }
}
