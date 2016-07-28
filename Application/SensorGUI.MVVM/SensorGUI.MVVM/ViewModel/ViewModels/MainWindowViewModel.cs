using MvvmDialogs;
using PropertyChanged;
using SensorGUI.MVVM.Helper;
using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Windows.Threading;
using commands;
using usb;
using model;
using System.Threading.Tasks;

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
        public bool GraphVisible { get; set; }
        public ValueSet AverageValue { get; set; }
        public ValueSet StandardDeviation { get; set; }
        public ValueSet MaxValue { get; set; }
        public ValueSet MinValue { get; set; }
        public ValueSet Live { get; set; }
        public ValueSet SelectedMeasurement { get; set; }
        public int SelectedIndex { get; set; }
        public RepeatingAccuracyMeasurementSeriesWrapper CurrentMeasurementSeries { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<RepeatingAccuracyMeasurementSeriesWrapper> MeasurementSeries { get; set; }
        public ObservableCollection<Configuration> Configs { get; set; }
        public DispatcherTimer DispatcherTimer { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int IDCounter { get; set; }

        private CommandExecuter executer;
        private MeasurementSeriesCollection measurementSeriesCollection;

        private readonly IDialogService DialogService;
        private string _path;
        #endregion
        public MainWindowViewModel(IDialogService DialogService) {
            #region Beispieldaten
            this.DialogService = DialogService;
            this.Users = new ObservableCollection<User>();
            this.Configs = new ObservableCollection<Configuration>();
            this.MeasurementSeries = new ObservableCollection<RepeatingAccuracyMeasurementSeriesWrapper>();


            USBAdaption.init(this);

            Console.WriteLine("After Init");

            this.executer = USBAdaption.getCommandExecuter();
            this.measurementSeriesCollection = new MeasurementSeriesCollection();
            this.CurrentMeasurementSeries = new RepeatingAccuracyMeasurementSeriesWrapper(new RepeatingAccuracyMeasurementSeries("Initial Series"));
            //this.measurementSeriesCollection.addMeasurementSeries(new RepeatingAccuracyMeasurementSeries("Neuer Messvorgang"));

            Console.WriteLine("After get Command Executer");

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
            this.GraphVisible = false;
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
            this.Live = new ValueSet { Value1 = 0.1234f, Value2 = 9.7654f, Value3 = 5.9182f };
            #endregion

            InitCommands();
            update();

            u1.NameChanged += U1_NameChanged;

            //var _ = UpdateValue();
            var _ = UpdateLiveValues();
        }

        /*private async Task UpdateValue() {
            for(int i = 0; i < 10; i++) {
                await Task.Delay(1000);
                AppCode = i.ToString();
            }
        }*/
        private async Task UpdateLiveValues() {
            while(true) {
                await Task.Delay(250);
                for(int i = 0; i < this.CurrentMeasurementSeries.Measurements.Count; i++) {
                    this.Live.Value1 = this.CurrentMeasurementSeries.Measurements[i].Value1;
                    this.Live.Value2 = this.CurrentMeasurementSeries.Measurements[i].Value2;
                    this.Live.Value3 = this.CurrentMeasurementSeries.Measurements[i].Value3;
                }
            }
        }
        public string Path {
            get { return _path; }
            private set { Set(() => Path, ref _path, value); }
        }

        public void update() 
        {
            Console.WriteLine("Update!");

            if(this.measurementSeriesCollection.getMeasurementSeriesLength() > 0) 
            {
                this.MeasurementSeries = ModelToWrappedModelParser.parse(this.measurementSeriesCollection);
                int lastIndex = this.MeasurementSeries.Count - 1;

                this.CurrentMeasurementSeries = this.MeasurementSeries[lastIndex];
                this.Title = CurrentMeasurementSeries.Name;
            }
            else 
            {
                this.Title = "";
            }
            this.UpdateExtraValues();
        }

        private void UpdateExtraValues() {
            ObservableCollection<ValueSet> values = RepeatingAccuracyMeasurementToValueSetParser.parse(this.CurrentMeasurementSeries);

            this.AverageValue = MathHelper.CalculateAverage(values);
            this.StandardDeviation = MathHelper.CalculateStandardDeviation(values);
            this.MaxValue = MathHelper.GetMaximum(values);
            this.MinValue = MathHelper.GetMinimum(values);
        }

    }
}
