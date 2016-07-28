using commands;
using commands.reactivecommands;
using commands.simplecommands;
using GalaSoft.MvvmLight.Ioc;
using model;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using usb;

namespace SensorGUI.MVVM {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) 
        {
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
        }

        private void printRepeatingAccuracyMeasurementSeries(RepeatingAccuracyMeasurementSeries series) {
            for (int i = 0; i < series.getMeasurementsLength(); i++)
            {
                Console.Write(series.getMeasurement(i).value1 + " " + series.getMeasurement(i).value2 + " " + series.getMeasurement(i).value3 + "\n");
            }
        }

        private void printWayTimeMeasurementSeries(WayTimeMeasurementSeries series) {
            for (int i = 0; i < series.getMeasurementsLength(); i++)
            {
                 Console.Write(series.getMeasurement(i).Item1 + " -> " + series.getMeasurement(i).Item2 + "; ");
            }
        }
    }
}
