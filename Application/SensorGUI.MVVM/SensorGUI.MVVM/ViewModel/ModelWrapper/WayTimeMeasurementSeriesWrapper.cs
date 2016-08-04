using model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class WayTimeMeasurementSeriesWrapper : MeasurementSeriesWrapper {

        public double Time { get; set; }
        public ObservableCollection<Tuple<double, double>> WayTimeMeasurements { get; set; }
        public ObservableCollection<Tuple<double, double>> VelocityTimeMeasurements {
            get {
                int size = WayTimeMeasurements.Count;
                ObservableCollection<Tuple<double, double>> collection = new ObservableCollection<Tuple<double, double>>();
                for(int i = 0; i < size; i++) {
                    double time = this.WayTimeMeasurements[i].Item1;


                    if(i == 0 || i == size - 1) {
                        collection.Add(new Tuple<double, double>(time, 0));
                    } else {

                        double value1 = this.WayTimeMeasurements[i - 1].Item2;
                        double value2 = this.WayTimeMeasurements[i + 1].Item2;

                        collection.Add(new Tuple<double, double>(time, value2 - value1));
                    }
                }

                return collection;
            }

            set { }
        }
        public ObservableCollection<Tuple<double, double>> AccelerationTimeMeasurements {
            get {
                int size = this.VelocityTimeMeasurements.Count;
                ObservableCollection<Tuple<double, double>> collection = new ObservableCollection<Tuple<double, double>>();
                for(int i = 0; i < size; i++) {
                    double time = this.VelocityTimeMeasurements[i].Item1;


                    if(i == 0 || i == size - 1) {
                        collection.Add(new Tuple<double, double>(time, 0));
                    } else {

                        double value1 = this.VelocityTimeMeasurements[i - 1].Item2;
                        double value2 = this.VelocityTimeMeasurements[i + 1].Item2;

                        collection.Add(new Tuple<double, double>(time, value2 - value1));
                    }
                }

                return collection;
            }

            set { }
        }

        public void addMeasurement(Tuple<double, double> measurement) {
            WayTimeMeasurements.Add(measurement);
        }

        public WayTimeMeasurementSeriesWrapper(WayTimeMeasurementSeries original) : base(original) {
            this.WayTimeMeasurements = new ObservableCollection<Tuple<double, double>>();
        }
    }
}
