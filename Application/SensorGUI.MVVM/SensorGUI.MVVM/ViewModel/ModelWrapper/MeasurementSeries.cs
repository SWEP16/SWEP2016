using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class MeasurementSeries {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Time { get; set; }
        public ConfigView Config { get; set; }
        public ObservableCollection<ValueSet> Measurements { get; set; }
        public MeasurementSeries() {
            this.Measurements = new ObservableCollection<ValueSet>();
        }
        public MeasurementSeries(string Name, int Id) {
            this.Name = Name;
            this.Id = Id;
            this.Measurements = new ObservableCollection<ValueSet>();
        }
    }
}
