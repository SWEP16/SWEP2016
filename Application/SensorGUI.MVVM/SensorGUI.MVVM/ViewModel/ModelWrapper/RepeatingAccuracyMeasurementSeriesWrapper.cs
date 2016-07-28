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
    public class RepeatingAccuracyMeasurementSeriesWrapper {

        private RepeatingAccuracyMeasurementSeries originalRepeatingAccuracyMeasurementSeriesWrapper;

        public string Name {
            get {
                return this.originalRepeatingAccuracyMeasurementSeriesWrapper.name;
            }
            set { }
        }
        public int Id { get; set; }
        public double Time { get; set; }

        public RepeatingAccuracyMeasurementSeries getOriginal() 
        {
            return this.originalRepeatingAccuracyMeasurementSeriesWrapper;
        }
        public ObservableCollection<KeyValuePair<double, double>> WayTime { get; set; }
        public ConfigView Config { get; set; }
        public ObservableCollection<RepeatingAccuracyMeasurementWrapper> Measurements { get; set; }
        public bool ExportChecked { get; set; }
        public RepeatingAccuracyMeasurementSeriesWrapper(RepeatingAccuracyMeasurementSeries original) {
            this.originalRepeatingAccuracyMeasurementSeriesWrapper = original;
            this.Measurements = new ObservableCollection<RepeatingAccuracyMeasurementWrapper>();
        }
        public void addRepeatingAccuracyMeasurement(RepeatingAccuracyMeasurementWrapper measurementWrapper) {
            this.Measurements.Add(measurementWrapper);
        }
    }
}
