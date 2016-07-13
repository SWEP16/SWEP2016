using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SensorGUI.MVVM
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            /*base.OnStartup(e);

            MainWindowViewModel viewmodel = new MainWindowViewModel();
            MainWindow mw = new MainWindow();
            mw.DataContext = viewmodel;
            mw.Show();*/
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
        }
    }
}
