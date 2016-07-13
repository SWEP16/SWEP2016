using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using usingExcel = Microsoft.Office.Interop.Excel;

namespace model {
    class Excel {
        public void createExcel(MeasurementSeriesCollection msc) {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            usingExcel.Workbook workbook = null;
            usingExcel.Sheets sheets = null;
            usingExcel.Worksheet newSheet = null;

            object misValue = System.Reflection.Missing.Value;

            try {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                workbook = excelApp.Workbooks.Add(usingExcel.XlSheetType.xlWorksheet);
                sheets = workbook.Sheets;

                for(int i = 0; i < msc.getMeasurementSeriesLength(); i++) {
                    newSheet = (usingExcel.Worksheet)sheets.Add(sheets[i+1], Type.Missing, Type.Missing, Type.Missing);
                  
                    newSheet.Name = msc.getMeasurementSeries(i).name;
                    //Repeating Accuaracy Measurment Series 
                    if (msc.getMeasurementSeries(i) is RepeatingAccuracyMeasurementSeries) {
                        RepeatingAccuracyMeasurementSeries ramcs = (RepeatingAccuracyMeasurementSeries)msc.getMeasurementSeries(i);
                        int row = 3;
                        int col = 1;

                        newSheet.Cells[1, 1] = "Sensor 1";
                        newSheet.Cells[1, 2] = "Sensor 2";
                        newSheet.Cells[1, 3] = "Sensor 3";

                        for (int j = 0; j<ramcs.getMeasurementsLength(); j++) {
                            
                            newSheet.Cells[row, col + 0] = ramcs.getMeasurement(j).value1;
                            newSheet.Cells[row, col + 1] = ramcs.getMeasurement(j).value2;
                            newSheet.Cells[row, col + 2] = ramcs.getMeasurement(j).value3;
                            row++;
                        }
                        row = 1;
                        col = 1;
                    }
                    //Way Time Measurement Series
                    else {
                        WayTimeMeasurementSeries wts = (WayTimeMeasurementSeries)msc.getMeasurementSeries(i);
                        int row = 3;
                        int col = 1;

                        newSheet.Cells[1, 1] = "s";
                        newSheet.Cells[1, 2] = "t";

                        for (int j = 0; j < wts.getMeasurementsLength(); j++) {
                            for(int k = 0; k < wts.getMeasurement(j).getValuesLegth(); k++) {
                                newSheet.Cells[row, col + 0] = wts.getMeasurement(j).getValue(k).Item1;
                                newSheet.Cells[row, col + 1] = wts.getMeasurement(j).getValue(k).Item2;
                                row++;                        
                            }             
                        }
                        row = 1;
                        col = 1;

                        usingExcel.Range chartRange;

                        usingExcel.ChartObjects xlCharts = (usingExcel.ChartObjects)newSheet.ChartObjects(Type.Missing);
                        usingExcel.ChartObject myChart = (usingExcel.ChartObject)xlCharts.Add(200, 10, 300, 250);
                        usingExcel.Chart chartPage = myChart.Chart;

                        chartRange = newSheet.get_Range("A1", "B6");
                        chartPage.SetSourceData(chartRange, misValue);
                        chartPage.ChartType = usingExcel.XlChartType.xlLine;

                        // workbook.SaveAs("csharp.net-informations.xls", usingExcel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, usingExcel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        // workbook.Close(true, misValue, misValue);
                        // excelApp.Quit();

                        /*releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);

                        MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");*/
                    }
                    usingExcel.Worksheet sheet = (usingExcel.Worksheet)sheets[1];
                    sheet.Select(Type.Missing);
                }
                
                //workbook.Save();
                //workbook.Close(null, null, null);
                //excelApp.Quit();
                excelApp.Visible = true;

            }
            finally {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(newSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                newSheet = null;
                sheets = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
            }
        }
    }
}
