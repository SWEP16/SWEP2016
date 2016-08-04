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
using commands.reactivecommands;

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
        public bool Loading { get; set; }
        public ValueSet AverageValue { get; set; }
        public ValueSet StandardDeviation { get; set; }
        public ValueSet MaxValue { get; set; }
        public ValueSet MinValue { get; set; }
        public RepeatingAccuracyMeasurementWrapper Live { get; set; }
        //public ValueSet SelectedMeasurement { get; set; }
        public int SelectedIndex { get; set; }
        public string ErrorMessage { get; set; }
        public bool ErrorVisible { get; set; }
        public ObservableCollection<MeasurementSeriesWrapper> MeasurementSeries { get; set; }
        public MeasurementSeriesWrapper CurrentMeasurementSeries { get; set; }
        public RepeatingAccuracyMeasurementSeriesWrapper CurrentAccuracySeries {
            get {
                if(CurrentMeasurementSeries is RepeatingAccuracyMeasurementSeriesWrapper) {
                    return (RepeatingAccuracyMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                }
                return new RepeatingAccuracyMeasurementSeriesWrapper(new RepeatingAccuracyMeasurementSeries("Messreihe um Rendering der View nicht zu behindern."));
            }
            set { }
        }
        public WayTimeMeasurementSeriesWrapper CurrentWayTimeSeries {
            get {
                if(CurrentMeasurementSeries is WayTimeMeasurementSeriesWrapper) {
                    return (WayTimeMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                }
                return new WayTimeMeasurementSeriesWrapper(new WayTimeMeasurementSeries("Messreihe um Rendering der View nicht zu behindern."));
            }
            set { }
        }
        public ObservableCollection<User> Users { get; set; }

        public DispatcherTimer DispatcherTimer { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public TimeSpan TimeSpan { get; set; }

        private CommandExecuter executer;
        private MeasurementSeriesCollection measurementSeriesCollection;

        private readonly IDialogService DialogService;
        private string _path;
        public string Path {
            get { return _path; }
            private set { Set(() => Path, ref _path, value); }
        }
        #endregion
        public MainWindowViewModel(IDialogService DialogService) {
            this.DialogService = DialogService;
            this.Users = new ObservableCollection<User>();
            this.MeasurementSeries = new ObservableCollection<MeasurementSeriesWrapper>();


            USBAdaption.init(this);

            Console.WriteLine("After Init");

            this.executer = USBAdaption.getCommandExecuter();
            this.measurementSeriesCollection = new MeasurementSeriesCollection();

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
            this.Loading = false;
            this.ConfigName = "Konfiguration auswählen...";
            this.Timer = "00:00";
            this.AppCode = "1337";
            this.DispatcherTimer = new DispatcherTimer();
            this.DispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            this.DispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            this.ErrorVisible = false;
            InitCommands();
            this.update();

            u1.NameChanged += U1_NameChanged;

            var _ = StartLiveUpdate();
        }


        private async Task StartLiveUpdate() {
            while(true) {
                await Task.Delay(250);
                if(this.executer.areQueuesEmpty() && (ConfigView == ConfigView.Genauigkeitsmessung || ConfigView == ConfigView.WegZeitMessung)) {
                    this.executer.execute(new ReadValueCommand());
                }
            }
        }


        public void update() {
            this.MeasurementSeries = ModelToWrappedModelParser.parse(this.measurementSeriesCollection);
            int lastIndex = this.MeasurementSeries.Count - 1;

            if(this.measurementSeriesCollection.getMeasurementSeriesLength() > 0) {
                this.CurrentMeasurementSeries = this.MeasurementSeries[lastIndex];
                this.Title = CurrentMeasurementSeries.Name;
            } else {
                this.Title = "";
                this.CurrentMeasurementSeries = null;
            }
            this.Loading = false;
            this.UpdateExtraValues();
        }

        private void UpdateExtraValues() {
            if(this.CurrentMeasurementSeries is RepeatingAccuracyMeasurementSeriesWrapper) {
                RepeatingAccuracyMeasurementSeriesWrapper currentMeasurementSeriesAsRepeatingMeasurementSeries = (RepeatingAccuracyMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                ObservableCollection<ValueSet> values = RepeatingAccuracyMeasurementToValueSetParser.parse(currentMeasurementSeriesAsRepeatingMeasurementSeries);

                this.AverageValue = MathHelper.CalculateAverage(values);
                this.StandardDeviation = MathHelper.CalculateStandardDeviation(values);
                this.MaxValue = MathHelper.GetMaximum(values);
                this.MinValue = MathHelper.GetMinimum(values);
            } else {
                this.AverageValue = new ValueSet { Value1 = 0, Value2 = 0, Value3 = 0 };
                this.StandardDeviation = new ValueSet { Value1 = float.NaN, Value2 = float.NaN, Value3 = float.NaN };
                this.MaxValue = new ValueSet { Value1 = 0, Value2 = 0, Value3 = 0 };
                this.MinValue = new ValueSet { Value1 = 0, Value2 = 0, Value3 = 0 };
            }
        }

        public void UpdateLiveValues(RepeatingAccuracyMeasurement measurement) {
            this.Live = new RepeatingAccuracyMeasurementWrapper(measurement);
            //Console.WriteLine("val 3: " + measurement.value3);
        }

        public void DisplayErrorMessage(string ErrorText) {
            this.ErrorMessage = ErrorText;
            this.ErrorVisible = true;
            //ShowErrorDialog(ViewModel => DialogService.ShowDialog<SensorGUI.MVVM.Views.ErrorWindow>(this, ViewModel));
            //MessageBoxResult result = this.DialogService.ShowMessageBox(this, ErrorText, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
