using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Test {
    class ModelTestSuite {
        private List<Tuple<string, UnitTest>> unitTests = new List<Tuple<string, UnitTest>>();

        public ModelTestSuite() {
            //UnitTest wtut = new WayTimeMeasurementUnitTest();
            this.unitTests.Add(Tuple.Create("WayTimeMeasurement", (UnitTest)new WayTimeMeasurementUnitTest()));
            this.unitTests.Add(Tuple.Create("WayTimeMeasurementSeries", (UnitTest)new WayTimeMeasurementSeriesUnitTest()));
            this.unitTests.Add(Tuple.Create("RepeatingAccuracyMeasurement", (UnitTest)new RepeatingAccuracyMeasurementUnitTest()));
            this.unitTests.Add(Tuple.Create("RepeatingAccuracyMeasurementSeries", (UnitTest)new RepeatingAccuracyMeasurementSeriesUnitTest()));
            this.unitTests.Add(Tuple.Create("MeasurementSeriesCollection", (UnitTest)new MeasurementSeriesCollectionUnitTest()));
        }
        public bool test() {
            bool passed = true;
            for (int i = 0; i < this.unitTests.Count(); i++) {
                if (this.unitTests.ElementAt(i).Item2.test()) {
                    Console.WriteLine(".");
                }
                else {
                    Console.WriteLine("x");
                    Console.WriteLine("Unit Test for '{0}' failed!", this.unitTests.ElementAt(i).Item1);
                    passed = false;
                }
            }
            return passed;
        }
    }
}
