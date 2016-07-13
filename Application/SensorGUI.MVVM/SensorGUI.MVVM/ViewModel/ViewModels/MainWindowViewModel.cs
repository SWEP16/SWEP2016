using MvvmDialogs;
using PropertyChanged;
using SensorGUI.MVVM.Helper;
using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Windows.Threading;
using model;
using SensorGUI.MVVM.ViewModel;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public partial class MainWindowViewModel : ViewModelBase {
        #region Properties
        public ApplicationState State { get; set; }
        public ConfigView ConfigView { get; set; }
        public string AppCode { get; set; }
        public string Title { get; set; }
        public string Timer { get; set; }
        public string ConfigName { get; set; }
        public bool ConfigEnabled { get; set; }
        public bool SeriesEnabled { get; set; }
        public bool StartEnabled { get; set; }
        public bool StartStop { get; set; }
        public ValueSet AverageValue { get; set; }
        public ValueSet StandardDeviation { get; set; }
        public ValueSet MaxValue { get; set; }
        public ValueSet MinValue { get; set; }
        public ValueSet Live { get; set; }
        public ValueSet SelectedMeasurement { get; set; }
        public int SelectedIndex { get; set; }
        public MeasurementSeriesWrapper CurrentMeasurementSeries { get; set; }
        public ObservableCollection<User> Users { get; set; }
        //public ObservableCollection<MeasurementSeries> MeasurementSeries { get; set; }
        public ObservableCollection<Configuration> Configs { get; set; }
        public DispatcherTimer DispatcherTimer { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int IDCounter { get; set; }

        private readonly IDialogService DialogService;
        #endregion
        public MainWindowViewModel(IDialogService DialogService) {
            #region Beispieldaten
            this.DialogService = DialogService;
            this.Users = new ObservableCollection<User>();
            this.Configs = new ObservableCollection<Configuration>();
            //this.MeasurementSeries = new ObservableCollection<MeasurementSeries>();

            /* Florians Model Tests Start*/
            RepeatingAccuracyMeasurementSeries series = new RepeatingAccuracyMeasurementSeries("Series 1");
            series.addMeasurement(new RepeatingAccuracyMeasurement(1, 1, 1));
            ViewModel.ModelToWrappedModelParser parser = new ModelToWrappedModelParser();
            this.CurrentMeasurementSeries = parser.parse(series);
            /* Florians Model Tests Ende */

            User u1 = new User { Name = "User 1", IsTriggerer = true };
            User u2 = new User { Name = "User 2", IsTriggerer = false };
            User u3 = new User { Name = "User 3", IsTriggerer = false };
            this.Users.Add(u1);
            this.Users.Add(u2);
            this.Users.Add(u3);
            this.ConfigEnabled = true;
            this.SeriesEnabled = false;
            this.StartEnabled = true;
            this.StartStop = true;
            this.ConfigName = "Konfiguration auswählen...";
            this.Timer = "00:00";
            this.IDCounter = 0;
            this.AppCode = "1337";
            this.DispatcherTimer = new DispatcherTimer();
            this.DispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            this.DispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Configuration c1 = new Configuration { Name = "Genauigkeitsmessung", Id = 0, Config = ConfigView.Genauigkeitsmessung };
            Configuration c2 = new Configuration { Name = "Weg-Zeit Messung", Id = 1, Config = ConfigView.WegZeitMessung };
            this.Configs.Add(c1);
            this.Configs.Add(c2);
            this.Live = new ValueSet(new RepeatingAccuracyMeasurement(1, 1, 1)); //new ValueSet { Value1 = 0.1234f, Value2 = 9.7654f, Value3 = 5.9182f };
            #endregion

            InitCommands();
            UpdateExtraValues();

            u1.NameChanged += U1_NameChanged;

            //var _ = UpdateValue();
        }

        /*private async Task UpdateValue() {
            for(int i = 0; i < 10; i++) {
                await Task.Delay(1000);
                AppCode = i.ToString();
            }
        }*/

        private void UpdateExtraValues() {
            /*
            this.AverageValue = MathHelper.CalculateAverage(this.CurrentMeasurementSeries.Measurements);
            this.StandardDeviation = MathHelper.CalculateStandardDeviation(this.CurrentMeasurementSeries.Measurements);
            this.MaxValue = MathHelper.GetMaximum(this.CurrentMeasurementSeries.Measurements);
            this.MinValue = MathHelper.GetMinimum(this.CurrentMeasurementSeries.Measurements);
            */
        }

    }
}
