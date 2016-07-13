using SensorGUI.MVVM.View.ViewModel;
using System;
using System.Linq;
using System.Windows.Input;

namespace SensorGUI.MVVM {
    public partial class MainWindowViewModel {
        #region Properties
        public ICommand ChangeTriggererCommand { get; set; }
        public ICommand ChangeConfigCommand { get; set; }
        public ICommand MeasurementNewCommand { get; set; }
        public ICommand MeasurementCancelCommand { get; set; }
        public ICommand MeasurementSaveCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand NewConfigCommand { get; set; }
        public ICommand ChangeMeasurementSeriesCommand { get; set; }
        public ICommand DeleteTriggeredValueCommand { get; set; }
        public ICommand TriggerCommand { get; set; }
        public ICommand CalibrateCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        #endregion
        private void InitCommands() {
            this.ChangeConfigCommand = new RelayCommand(ChangeConfigExecute, ChangeConfigCanExecute);
            this.ChangeTriggererCommand = new RelayCommand(ChangeTriggererExecute, ChangeTriggererCanExecute);
            this.MeasurementNewCommand = new RelayCommand(MeasurementNewExecute, MeasurementNewCanExcecute);
            this.MeasurementCancelCommand = new RelayCommand(MeasurementCancelExecute, MeasurementCancelCanExcecute);
            this.MeasurementSaveCommand = new RelayCommand(MeasurementSaveExecute, MeasurementSaveCanExcecute);
            this.ExportCommand = new RelayCommand(ExportExecute, ExportCanExecute);
            this.NewConfigCommand = new RelayCommand(NewConfigExecute, NewConfigCanExecute);
            this.ChangeMeasurementSeriesCommand = new RelayCommand(ChangeMeasurementSeriesExecute, ChangeMeasurementSeriesCanExecute);
            this.TriggerCommand = new RelayCommand(TriggerExecute, TriggerCanExecute);
            this.CalibrateCommand = new RelayCommand(CalibrateExecute, CalibrateCanExecute);
            this.DeleteTriggeredValueCommand = new RelayCommand(DeleteTriggeredValueExecute, DeleteTriggeredValueCanExecute);
            this.StartCommand = new RelayCommand(StartExecute, StartCanExecute);
            this.StopCommand = new RelayCommand(StopExecute);
        }

        #region -----Executes-----
        private void ChangeConfigExecute(object obj) {
            foreach(var item in Configs) {
                if((int)obj == item.Id) {
                    this.ConfigView = item.Config;
                    this.ConfigName = item.Name;
                    this.CurrentMeasurementSeries = new MeasurementSeries();
                    this.Title = "";
                    State = ApplicationState.Ready;
                }
            }
        }
        private void MeasurementNewExecute(object obj) {
            this.ConfigEnabled = false;
            this.SeriesEnabled = false;
            this.StartEnabled = true;
            this.CurrentMeasurementSeries = new MeasurementSeries("Neuer Messvorgang", this.IDCounter++);
            this.Title = CurrentMeasurementSeries.Name;
            State = ApplicationState.Measuring;
            UpdateExtraValues();
        }

        private void MeasurementCancelExecute(object obj) {
            ShowCancelDialog(ViewModel => DialogService.ShowDialog<SensorGUI.MVVM.Views.CancelWindow>(this, ViewModel));
        }
        private void ShowCancelDialog(Func<CancelWindowViewModel, bool?> showDialog) {
            var DialogViewModel = new CancelWindowViewModel();

            bool? success = showDialog(DialogViewModel);
            if(success == true) {
                this.ConfigEnabled = true;
                this.Timer = "00:00";
                if (this.MeasurementSeries.Count != 0) {
                    this.SeriesEnabled = true;
                }
                this.Title = "";
                State = ApplicationState.Ready;
                this.CurrentMeasurementSeries.Measurements.Clear();
            }
        }

        private void MeasurementSaveExecute(object obj) {
            ShowSaveDialog(ViewModel => DialogService.ShowDialog<SensorGUI.MVVM.Views.SaveWindow>(this, ViewModel));
        }
        private void ShowSaveDialog(Func<SaveWindowViewModel, bool?> showDialog) {
            var DialogViewModel = new SaveWindowViewModel();

            bool? success = showDialog(DialogViewModel);
            if (success == true)
            {
                this.ConfigEnabled = true;
                this.SeriesEnabled = true;
                this.Timer = "00:00";
                this.CurrentMeasurementSeries.Name = DialogViewModel.Text;
                if (CurrentMeasurementSeries.Time == 0)
                {
                    this.CurrentMeasurementSeries.Config = ConfigView.Genauigkeitsmessung;
                }
                else
                {
                    this.CurrentMeasurementSeries.Config = ConfigView.WegZeitMessung;
                }
                this.Title = CurrentMeasurementSeries.Name;
                this.MeasurementSeries.Add(this.CurrentMeasurementSeries);
                State = ApplicationState.Ready;
            }
        }

        private void ExportExecute(object obj) {
            // TODO: Popup, Call Export Function
        }

        private void NewConfigExecute(object obj) {
            // TODO: Popup, Call New Config Function
        }

        private void ChangeMeasurementSeriesExecute(object obj) {
            foreach (var item in MeasurementSeries)
            {
                if ((int)obj == item.Id)
                {
                    this.Title = item.Name;
                    this.CurrentMeasurementSeries = item;
                    this.ConfigView = item.Config;
                    this.ConfigName = item.Config.ToFriendlyString();
                    UpdateExtraValues();
                }
            }
        }

        private void TriggerExecute(object obj) {
            this.StartEnabled = false;
            // TODO: Call Trigger Function
            ValueSet neu = new ValueSet { Value1 = 0.1234f, Value2 = 5.3142f, Value3 = 3.1415f };
            this.CurrentMeasurementSeries.Measurements.Add(neu);
            UpdateExtraValues();
        }

        private void CalibrateExecute(object obj) {
            // TODO: Call Calibrate Function
        }

        private void DeleteTriggeredValueExecute(object e) {
            if (this.SelectedIndex != -1)
            {
                this.CurrentMeasurementSeries.Measurements.RemoveAt(this.SelectedIndex);
                UpdateExtraValues();
            }
        }

        private void StartExecute(object obj) {
            this.Stopwatch = new System.Diagnostics.Stopwatch();
            this.Stopwatch.Start();
            this.DispatcherTimer.Start();
            this.StartStop = false;
        }
        private void StopExecute(object obj) {
            this.CurrentMeasurementSeries.Time = this.TimeSpan.TotalMilliseconds;
            this.Stopwatch.Stop();
            this.Stopwatch.Reset();
            this.StartStop = true;
            this.StartEnabled = false;
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e) {
            if(this.Stopwatch.IsRunning) {
                this.TimeSpan = this.Stopwatch.Elapsed;
                this.Timer = String.Format("{0:00}:{1:00}",
                    this.TimeSpan.Minutes, this.TimeSpan.Seconds);
                this.CurrentMeasurementSeries.Measurements.Add(new ValueSet { Value1 = 1.4241f, Value2 = 1.4241f, Value3 = 1.4241f });
            }
        }

        private void ChangeTriggererExecute(object e) {
            var id = (Guid)e;
            foreach(var item in this.Users.Where(u => u.IsTriggerer)) {
                item.IsTriggerer = false;
            }
            var user = this.Users.FirstOrDefault(u => u.Id == id);
            if(user != null) {
                user.IsTriggerer = true;
            }
            // TODO: Inform mobile devices
        }

        private void U1_NameChanged(object sender, NameChangedEventArgs e) {
            Console.WriteLine($"Name changed to {e.NewValue}");
            string.Format("Name changed to {0}", e.NewValue);
        }
        #endregion

        #region -----CanExecutes-----
        private bool ChangeConfigCanExecute(object obj) {
            return State == ApplicationState.Idle || State == ApplicationState.Ready;
        }
        private bool MeasurementNewCanExcecute(object obj) {
            return State == ApplicationState.Ready;
        }
        private bool MeasurementCancelCanExcecute(object obj) {
            return State == ApplicationState.Measuring;
        }
        private bool MeasurementSaveCanExcecute(object obj) {
            return State == ApplicationState.Measuring && this.CurrentMeasurementSeries.Measurements.Count != 0 && this.StartEnabled == false;
        }
        private bool ExportCanExecute(object obj) {
            return State == ApplicationState.Ready;
        }
        private bool NewConfigCanExecute(object obj) {
            return State == ApplicationState.Idle || State == ApplicationState.Ready;
        }
        private bool ChangeMeasurementSeriesCanExecute(object obj) {
            return this.MeasurementSeries.Count != 0 && State == ApplicationState.Ready;
        }
        private bool TriggerCanExecute(object obj) {
            return State == ApplicationState.Measuring;
        }
        private bool CalibrateCanExecute(object obj) {
            return State == ApplicationState.Measuring;
        }
        private bool DeleteTriggeredValueCanExecute(object obj) {
            return this.CurrentMeasurementSeries.Measurements.Count != 0 && State == ApplicationState.Measuring;
        }
        private bool StartCanExecute(object obj) {
            return State == ApplicationState.Measuring;
        }
        private bool ChangeTriggererCanExecute(object obj) {
            return (!this.Users.Any(u => u.Id == (Guid)obj && u.IsTriggerer)) && (State == ApplicationState.Idle || State == ApplicationState.Ready);
        }
        #endregion
    }
}
