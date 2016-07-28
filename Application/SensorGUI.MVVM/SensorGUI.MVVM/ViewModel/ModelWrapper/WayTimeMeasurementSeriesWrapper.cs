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
    public class WayTimeMeasurementSeriesWrapper : MeasurementSeriesWrapper{
      
        public double Time { get; set; }
        public ObservableCollection<Tuple<double, double>> WayTimeMeasurements
        {
            get 
            {
                WayTimeMeasurementSeries original = (WayTimeMeasurementSeries)(this.originalMeasurementSeries);
                ObservableCollection<Tuple<double, double>> observableCollection = new ObservableCollection<Tuple<double, double>>();
                for(int i=0; i<original.getMeasurementsLength(); i++) 
                {
                    observableCollection.Add(original.getMeasurement(i));
                }

                return observableCollection;
            }

            set { }
        }

        public WayTimeMeasurementSeriesWrapper(WayTimeMeasurementSeries original) : base (original) 
        {
            this.WayTimeMeasurements = new ObservableCollection<Tuple<double, double>>();
        }
    }
}
