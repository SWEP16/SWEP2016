using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace commands {
    namespace simplecommands {
        public class RemoveLastMeasurementFromMeasurementSeriesCommand : SimpleCommand {
            private MeasurementSeriesCollection seriesCollection;
            public RemoveLastMeasurementFromMeasurementSeriesCommand(MeasurementSeriesCollection seriesCollection) {
                this.seriesCollection = seriesCollection;
            }

            public void execute() {
                int lastIndex = this.seriesCollection.getMeasurementSeriesLength() - 1;
                this.seriesCollection.removeMeasurementSeries(lastIndex);
            }
        }
    }
}
