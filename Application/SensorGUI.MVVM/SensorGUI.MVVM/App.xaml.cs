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
    }
}
