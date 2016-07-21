using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usb;
using commands;
using commands.reactivecommands;
using commands.simplecommands;
using model;


class Program
{
    static void Main(string[] args)
    {
        USBAdaption.init();

        WayTimeMeasurementSeries series = new WayTimeMeasurementSeries("Meine Messung 1");

        CommandExecuter executer = USBAdaption.getCommandExecuter();
        
        
        while (true)
        {
            executer.execute(new ReadValueCommand());
            System.Threading.Thread.Sleep(1000);
        }
        
       /*
        executer.executeOnPort1(new InitAccumulation());
        executer.executeOnPort1(new StartAccumulation());
        System.Threading.Thread.Sleep(1000);
        //doStupidshitOflife();
        executer.executeOnPort1(new StopAccumulation());
        System.Threading.Thread.Sleep(1000);
        //doStupidshitOflife();
        executer.executeOnPort1(new OutputAccumulation(series));
        

        List<Tuple<double, double>> values = new List<Tuple<double, double>>();
        Tuple<double, double> tuple = new Tuple<double, double>(0, 5.0001);
        Tuple<double, double> tuple2 = new Tuple<double, double>(0, 4.0008);
        values.Add(tuple);
        values.Add(tuple2);
        WayTimeMeasurement w1 = new WayTimeMeasurement(values);
        series.addMeasurement(w1);


        Program.printWayTimeMeasurementSeries(series);
        */
        //Console.Clear();
        

        Console.WriteLine("Ende");
        int line = Console.Read();
    }

    static void printRepeatingAccuracyMeasurementSeries(RepeatingAccuracyMeasurementSeries series)
    {
        for(int i=0; i<series.getMeasurementsLength(); i++)
        {
            Console.Write(series.getMeasurement(i).value1 + " " + series.getMeasurement(i).value2 + " " + series.getMeasurement(i).value3 + "\n");
        }
    }

    static void printWayTimeMeasurementSeries(WayTimeMeasurementSeries series)
    {
        for (int i = 0; i < series.getMeasurementsLength(); i++)
        {
           for(int j=0; j < series.getMeasurement(i).getValuesLength(); j++)
            {
                Console.Write(series.getMeasurement(i).getValue(j).Item1 + " -> " + series.getMeasurement(i).getValue(j).Item2+"; ");
            }
        }
    }

    static void doStupidshitOflife()
    {
        for(int i = 0; i < 100000; i++)
        {
            int a = i - 1;
            for (int j = 0; j < 10000; j++)
            {
                int b = i - 1;

            }
        }
        Console.WriteLine("End of wait");
    }
}