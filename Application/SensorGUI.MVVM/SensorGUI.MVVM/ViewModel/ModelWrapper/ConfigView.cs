using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    public enum ConfigView {
        Idle, Genauigkeitsmessung, WegZeitMessung
    }

    public static class ConfigExtensions {
        public static string ToFriendlyString(this ConfigView me) {
            switch(me) {
                case ConfigView.Idle:
                    return "Konfiguration auswählen...";
                case ConfigView.WegZeitMessung:
                    return "Weg-Zeit Messung";
                case ConfigView.Genauigkeitsmessung:
                    return "Genauigkeitsmessung";
            }
            return "Konfiguration auswählen...";
        }
    }

}
