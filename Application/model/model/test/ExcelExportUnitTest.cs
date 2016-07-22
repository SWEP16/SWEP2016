using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;

using model;

namespace test
{
    class ExcelExportUnitTest : UnitTest
    {
      public override bool test()
      {
        MeasurementSeriesCollection seriesCollection = new MeasurementSeriesCollection();

        // Test 1
        RepeatingAccuracyMeasurementSeries series1 = new RepeatingAccuracyMeasurementSeries("Series1");

        series1.addMeasurement(new RepeatingAccuracyMeasurement(20, 10, -4));
        series1.addMeasurement(new RepeatingAccuracyMeasurement(1.4, 0.32, -0.2));
        series1.addMeasurement(new RepeatingAccuracyMeasurement(0.0, 2, -3));

        seriesCollection.addMeasurementSeries(series1);

        // Test 2
        RepeatingAccuracyMeasurementSeries series2 = new RepeatingAccuracyMeasurementSeries("Series2");

        seriesCollection.addMeasurementSeries(series2);

        // Test 3
        WayTimeMeasurementSeries series3 = new WayTimeMeasurementSeries("Series3");

        List<Tuple<double, double>> values = new List<Tuple<double, double>>();

        values.Add(new Tuple<double, double>(0.3, 2.3));
        values.Add(new Tuple<double, double>(0.5, -2));
        values.Add(new Tuple<double, double>(0.6, -4.3));
        values.Add(new Tuple<double, double>(0.9, 8.3));

        series3.addMeasurement(new WayTimeMeasurement(values));

        seriesCollection.addMeasurementSeries(series3);


        Excel test = new Excel();
        test.createExcel(seriesCollection);
        //ExcelExportService.export(seriesCollection);

        return true;
      }
    }
}
