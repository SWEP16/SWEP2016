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
    public class MeasurementSeriesWrapper {

        private MeasurementSeries orginalMeasurementSeries;

        private string _Name; 
        public string Name
        {
            get
            {
                return this.orginalMeasurementSeries.name;
            }

            set
            {
                this._Name = value;
            }
        }

        public string getName()
        {
            return this.orginalMeasurementSeries.name;
        }
        public int Id { get; set; }
        public double Time { get; set; }
        public ConfigView Config { get; set; }
        public ObservableCollection<ValueSet> Measurements { get; set; }
        public MeasurementSeriesWrapper(RepeatingAccuracyMeasurementSeries orginalMeasurementSeries) 
        {
            this.Measurements = new ObservableCollection<ValueSet>();
            this.orginalMeasurementSeries = orginalMeasurementSeries;
            this.Id = 4;
            this.Time = 1.1;
            this.Config = ConfigView.Genauigkeitsmessung;
        }

        public void addRepeatingAccuracyMeasurement(ValueSet measurement) 
        {
            this.Measurements.Add(measurement);
        }
    }
}
