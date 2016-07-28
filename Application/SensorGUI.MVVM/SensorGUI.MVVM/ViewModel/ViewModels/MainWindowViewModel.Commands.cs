using commands.reactivecommands;
using commands.simplecommands;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using SensorGUI.MVVM.View.ViewModel;
using System;
using System.Linq;
using System.Windows.Input;
using model;

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
            var settings = new OpenFileDialogSettings {
                Title = "Konfiguration auswählen...",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "XML Documents (*.xml)|*.xml|All Files (*.*)|*.*"
            };

            bool? success = DialogService.ShowOpenFileDialog(this, settings);
            if(success == true) {
                Path = settings.FileName;
                executer.execute(new ConfigFromXMLCommand(executer, Path));
                String[] substrings = Path.Split('\\');
                string filename = substrings.Last();
                String[] fileSubstrings = filename.Split('.');
                string configIdentifier = fileSubstrings.ElementAt(1);
                
                if(configIdentifier.Equals("g", StringComparison.InvariantCultureIgnoreCase)) {
                    this.ConfigView = ConfigView.Genauigkeitsmessung;
                    this.ConfigName = "Genauigkeitsmessung";
                } else if(configIdentifier.Equals("wz", StringComparison.InvariantCultureIgnoreCase)) {
                    this.ConfigView = ConfigView.WegZeitMessung;
                    this.ConfigName = "Weg-Zeit Messung";
                }
                this.Title = "";
                State = ApplicationState.Ready;
            }
        }

        private void MeasurementNewExecute(object obj) {
            this.ConfigEnabled = false;
            this.SeriesEnabled = false;
            this.StartEnabled = true;
            if(this.ConfigView == ConfigView.Genauigkeitsmessung) {
                this.executer.execute(new AddRepeatingAccuracyMeasurementSeriesToMeasurementSeriesCollectionCommand("Neuer Messvorgang", this.measurementSeriesCollection));
            } else if(this.ConfigView == ConfigView.WegZeitMessung) {
                this.executer.execute(new AddWayTimeMeasurementSeriesToMeasurementSeriesCollectionCommand("Neuer Messvorgang", this.measurementSeriesCollection));
            }
            State = ApplicationState.Measuring;
        }

        private void MeasurementCancelExecute(object obj) {
            ShowCancelDialog(ViewModel => DialogService.ShowDialog<SensorGUI.MVVM.Views.CancelWindow>(this, ViewModel));
        }
        private void ShowCancelDialog(Func<CancelWindowViewModel, bool?> showDialog) {
            var DialogViewModel = new CancelWindowViewModel();

            bool? success = showDialog(DialogViewModel);
            if(success == true) {
                this.ConfigEnabled = true;
                this.Timer = "00:00:00";
                if(this.MeasurementSeries.Count != 0) {
                    this.SeriesEnabled = true;
                }
                this.executer.execute(new RemoveLastMeasurementFromMeasurementSeriesCommand(this.measurementSeriesCollection));
                State = ApplicationState.Ready;
                this.update();
            }
        }

        private void MeasurementSaveExecute(object obj) {
            ShowSaveDialog(ViewModel => DialogService.ShowDialog<SensorGUI.MVVM.Views.SaveWindow>(this, ViewModel));
        }
        private void ShowSaveDialog(Func<SaveWindowViewModel, bool?> showDialog) {
            var DialogViewModel = new SaveWindowViewModel();

            bool? success = showDialog(DialogViewModel);
            if(success == true) {
                this.ConfigEnabled = true;
                this.SeriesEnabled = true;
                this.Timer = "00:00:00";
                this.executer.execute(new ChangeNameOfLastMeasurementSeriesCommand(this.measurementSeriesCollection, DialogViewModel.Text));
                if(CurrentMeasurementSeries is RepeatingAccuracyMeasurementSeriesWrapper) {
                    this.CurrentMeasurementSeries.Config = ConfigView.Genauigkeitsmessung;
                } else if(CurrentMeasurementSeries is WayTimeMeasurementSeriesWrapper) {
                    this.CurrentMeasurementSeries.Config = ConfigView.WegZeitMessung;
                }
                State = ApplicationState.Ready;
            }
        }

        private void ExportExecute(object obj) {
            ShowExportDialog(ViewModel => DialogService.ShowDialog<SensorGUI.MVVM.Views.ExportWindow>(this, ViewModel));
        }
        private void ShowExportDialog(Func<ExportWindowViewModel, bool?> showDialog) {
            var DialogViewModel = new ExportWindowViewModel();

            bool? success = showDialog(DialogViewModel);
            if(success == true) {
                MeasurementSeriesCollection measurementSeriesCollectionForExcelExport = new MeasurementSeriesCollection();
                this.ConfigEnabled = true;
                this.SeriesEnabled = true;
                foreach(var item in this.MeasurementSeries) {
                    if(item.ExportChecked == true) {
                        measurementSeriesCollectionForExcelExport.addMeasurementSeries(item.getOriginal());
                    }
                }
                this.executer.execute(new ExportToExcelCommand(measurementSeriesCollectionForExcelExport));
            }
        }

        private void NewConfigExecute(object obj) {
            // TODO: Popup, Call New Config Function
        }

        private void ChangeMeasurementSeriesExecute(object obj) {
            foreach(var item in MeasurementSeries) {
                if((int)obj == item.Id) {
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
            this.executer.execute(new TriggerValueCommand(this.measurementSeriesCollection));
            //TODO: Change Sleep to reactive Update
        }

        private void CalibrateExecute(object obj) {
            this.executer.execute(new AutoZeroOnCommand());
        }

        private void DeleteTriggeredValueExecute(object e) {
            if(this.SelectedIndex != -1) {
                this.executer.execute(new RemoveRepeatingAccuracyMeasurementFromLastRepeatingAccuracyMeasurementSeriesCommand(this.measurementSeriesCollection, this.SelectedIndex));
            }
        }

        private void StartExecute(object obj) {
            this.Stopwatch = new System.Diagnostics.Stopwatch();
            this.Stopwatch.Start();
            this.DispatcherTimer.Start();
            this.StartStop = false;
            this.GraphVisible = true;
            this.executer.executeOnPort1(new InitAccumulationCommand());
            this.executer.executeOnPort1(new StartAccumulationCommand());
        }
        private void StopExecute(object obj) {
            if(this.CurrentMeasurementSeries is WayTimeMeasurementSeriesWrapper) {
                WayTimeMeasurementSeriesWrapper currentMeasurementSeriesAsWayTimeMeasurementSeries = (WayTimeMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                currentMeasurementSeriesAsWayTimeMeasurementSeries.Time = this.TimeSpan.TotalMilliseconds;
                this.executer.executeOnPort1(new StopAccumulationCommand());
                this.executer.executeOnPort1(new OutputAccumulationCommand(this.measurementSeriesCollection));
                //this.TestSeries = currentMeasurementSeriesAsWayTimeMeasurementSeries;
            }
            this.Stopwatch.Stop();
            this.Stopwatch.Reset();
            this.StartStop = true;
            this.StartEnabled = false;
            this.GraphVisible = true;
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e) {
            if(this.Stopwatch.IsRunning) {
                this.TimeSpan = this.Stopwatch.Elapsed;
                this.Timer = String.Format("{0:00}:{1:00}:{2:00}",
                    this.TimeSpan.Minutes, this.TimeSpan.Seconds, this.TimeSpan.Milliseconds);
                //this.executer.execute(new WayTimeValueCommand(this.measurementSeriesCollection, this.TimeSpan.TotalMilliseconds));
                //this.CurrentMeasurementSeries.WayTime.Add(new System.Collections.Generic.KeyValuePair<double, double>(this.TimeSpan.TotalSeconds, 1.4241));
            }
        }

        private void ChangeTriggererExecute(object e) {
            var id = (int)e;
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
            if(this.CurrentMeasurementSeries is RepeatingAccuracyMeasurementSeriesWrapper) {
                RepeatingAccuracyMeasurementSeriesWrapper currentMeasurementSeriesAsRepeatingMeasurementSeries = (RepeatingAccuracyMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                return State == ApplicationState.Measuring && currentMeasurementSeriesAsRepeatingMeasurementSeries.Measurements.Count != 0 && this.StartEnabled == false;
            } else {
                WayTimeMeasurementSeriesWrapper currentMeasurementSeriesAsRepeatingMeasurementSeries = (WayTimeMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                return State == ApplicationState.Measuring && currentMeasurementSeriesAsRepeatingMeasurementSeries.WayTimeMeasurements.Count != 0 && this.StartEnabled == false;
            }
        }
        private bool ExportCanExecute(object obj) {
            return State == ApplicationState.Ready && this.measurementSeriesCollection.getMeasurementSeriesLength() != 0;
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
            if(this.CurrentMeasurementSeries is RepeatingAccuracyMeasurementSeriesWrapper) {
                RepeatingAccuracyMeasurementSeriesWrapper currentMeasurementSeriesAsRepeatingMeasurementSeries = (RepeatingAccuracyMeasurementSeriesWrapper)(this.CurrentMeasurementSeries);
                return currentMeasurementSeriesAsRepeatingMeasurementSeries.Measurements.Count != 0 && State == ApplicationState.Measuring;
            }
            return false;
        }
        private bool StartCanExecute(object obj) {
            return State == ApplicationState.Measuring;
        }
        private bool ChangeTriggererCanExecute(object obj) {
            return (!this.Users.Any(u => u.Id == (int)obj && u.IsTriggerer)) && (State == ApplicationState.Idle || State == ApplicationState.Ready);
        }
        #endregion
    }
}
