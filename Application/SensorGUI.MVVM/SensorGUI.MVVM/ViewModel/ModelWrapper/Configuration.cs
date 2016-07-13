using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class Configuration {
        public string Name { get; set; }
        public int Id { get; set; }
        public ConfigView Config { get; set; }
    }
}
