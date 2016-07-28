using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SensorGUI.MVVM {
    public class ExportWindowViewModel : ViewModelBase, IModalDialogViewModel {
        private bool? _dialogResult;
        public ICommand OkCommand { get; set; }
        public ExportWindowViewModel() {
            this.OkCommand = new RelayCommand(OkExecute);
        }
        public bool? DialogResult
        {
            get { return _dialogResult; }
            private set { Set(nameof(DialogResult), ref _dialogResult, value); }
        }

        private void OkExecute() {
            DialogResult = true;
        }
    }
}