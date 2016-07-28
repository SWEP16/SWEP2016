using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class ValueSet {
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }

    }
}
