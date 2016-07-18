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
        RepeatingAccuracyMeasurementSeries rams = new RepeatingAccuracyMeasurementSeries("Meine Messung 1");

        CommandExecuter executer = USBAdaption.getCommandExecuter();
        while(true)
        {
            //executer.execute(new ReadValueCommand());
            Program.printRepeatingAccuracyMeasurementSeries(rams);
            executer.execute(new TriggerValueCommand(rams));
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

    }
    static void printRepeatingAccuracyMeasurementSeries(RepeatingAccuracyMeasurementSeries series)
    {
        for(int i=0; i<series.getMeasurementsLength(); i++)
        {
            Console.Write(series.getMeasurement(i).value1 + " " + series.getMeasurement(i).value2 + " " + series.getMeasurement(i).value3 + "\n");
        }
    }
}