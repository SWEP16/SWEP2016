using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;

namespace model {
    class Excel {

        public void createExcel(MeasurementSeriesCollection msc) {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook workbook = null;
            Sheets sheets = null;
            Worksheet newSheet = null;

            try {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                workbook = excelApp.Workbooks.Add(XlSheetType.xlWorksheet);
                sheets = workbook.Sheets;

                for(int i = 0; i < msc.getMeasurementSeriesLength(); i++) {
                    newSheet = (Worksheet)sheets.Add(sheets[i+1], Type.Missing, Type.Missing, Type.Missing);
                  
                    newSheet.Name = msc.getMeasurementSeries(i).name;

                    if (msc.getMeasurementSeries(i) is RepeatingAccuracyMeasurementSeries) {
                        RepeatingAccuracyMeasurementSeries ramcs = (RepeatingAccuracyMeasurementSeries)msc.getMeasurementSeries(i);
                        int row = 3;
                        int col = 1;

                        newSheet.Cells[1, 1] = "x";
                        newSheet.Cells[1, 2] = "y";
                        newSheet.Cells[1, 3] = "z";

                        for (int j = 0; j<ramcs.getMeasurementsLength(); j++) {
                            
                            newSheet.Cells[row, col + 0] = ramcs.getMeasurement(j).x;
                            newSheet.Cells[row, col + 1] = ramcs.getMeasurement(j).y;
                            newSheet.Cells[row, col + 2] = ramcs.getMeasurement(j).z;
                            row++;
                        }
                        row = 1;
                        col = 1;
                    }
                    else {
                        //To implement
                    }
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
