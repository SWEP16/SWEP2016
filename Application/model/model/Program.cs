using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using model;
using test;
using test.model;

class Program
{
    static void Main(string[] args) {
        ModelTestSuite modelTestSuide = new ModelTestSuite();
        ExcelExportUnitTest excelTest = new ExcelExportUnitTest();

        if (modelTestSuide.test())
        {
            Console.WriteLine("Model Tests bestanden!");
        }

        if (excelTest.test())
        {
            Console.WriteLine("Excel Datei erstellt!");
        }

        Console.ReadLine();
    }
}
