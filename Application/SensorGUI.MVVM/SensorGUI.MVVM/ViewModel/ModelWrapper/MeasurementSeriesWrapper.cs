using model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
     public abstract class MeasurementSeriesWrapper {

        protected MeasurementSeries originalMeasurementSeries;

        public string Name {
            get {
                return this.originalMeasurementSeries.name;
            }
            set { }
        }
        public int Id { get; set; }
        public bool ExportChecked { get; set; }
        public ConfigView Config { get; set; }
        public MeasurementSeries getOriginal() 
        {
            return this.originalMeasurementSeries;
        }

        public MeasurementSeriesWrapper(MeasurementSeries original) 
        {
            this.originalMeasurementSeries = original;       
        }
    }
}