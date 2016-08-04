using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGUI.MVVM {
    public class ViewModelLocator {
        public ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<SaveWindowViewModel>();
            SimpleIoc.Default.Register<CancelWindowViewModel>();
            SimpleIoc.Default.Register<ExportWindowViewModel>();
            SimpleIoc.Default.Register<ErrorWindowViewModel>();
        }

        public MainWindowViewModel MainWindow => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public SaveWindowViewModel SaveWindow => ServiceLocator.Current.GetInstance<SaveWindowViewModel>();
        public CancelWindowViewModel CancelWindow => ServiceLocator.Current.GetInstance<CancelWindowViewModel>();
        public ExportWindowViewModel ExportWindow => ServiceLocator.Current.GetInstance<ExportWindowViewModel>();
        public ErrorWindowViewModel ErrorWindow => ServiceLocator.Current.GetInstance<ErrorWindowViewModel>();
    }
}
