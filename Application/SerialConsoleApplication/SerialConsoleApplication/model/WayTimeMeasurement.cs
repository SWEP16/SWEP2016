using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model{
    public class WayTimeMeasurement{
        private List<Tuple<double, double>> values;

        public WayTimeMeasurement(List<Tuple<double, double>> values){
            this.values = values;
        }
        public int getValuesLength(){
            return this.values.Count();
        }
        public Tuple<double, double> getValue(int valueIndex) {
            return this.values.ElementAt(valueIndex);
        }
    }
}