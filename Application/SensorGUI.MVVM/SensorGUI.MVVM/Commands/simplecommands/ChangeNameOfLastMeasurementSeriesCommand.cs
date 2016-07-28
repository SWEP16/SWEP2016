using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace commands {
    namespace simplecommands {
        public class ChangeNameOfLastMeasurementSeriesCommand : SimpleCommand {
            private MeasurementSeriesCollection seriesCollection;
            private String name;

            public ChangeNameOfLastMeasurementSeriesCommand(MeasurementSeriesCollection seriesCollection, String name) {
                this.seriesCollection = seriesCollection;
                this.name = name;
            }

            public void execute() {
                int lastIndex = this.seriesCollection.getMeasurementSeriesLength() - 1;
                MeasurementSeries series = this.seriesCollection.getMeasurementSeries(lastIndex);
                series.setName(this.name);
            }
        }
    }
}
