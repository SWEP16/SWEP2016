using commands.reactivecommands;
using model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;

namespace commands {
    namespace simplecommands {
        public class AddWayTimeMeasurementSeriesToMeasurementSeriesCollectionCommand : SimpleCommand {

            public MeasurementSeriesCollection msc;
            public String name;

            public AddWayTimeMeasurementSeriesToMeasurementSeriesCollectionCommand(String name, MeasurementSeriesCollection msc) {
                this.msc = msc;
                this.name = name;
            }
            public void execute() {
                this.msc.addMeasurementSeries(new WayTimeMeasurementSeries(this.name));
            }
        }
    }
}
