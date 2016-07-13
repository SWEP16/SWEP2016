using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SensorGUI.MVVM {
    public class SaveWindowViewModel : ViewModelBase, IModalDialogViewModel {
        private bool? _dialogResult;
        private string _text;
        public ICommand OkCommand { get; set; }
        public SaveWindowViewModel() {
            this.OkCommand = new RelayCommand(OkExecute);
        }
        public bool? DialogResult {
            get { return _dialogResult; }
            private set { Set(nameof(DialogResult), ref _dialogResult, value); }
        }

        public string Text {
            get { return _text; }
            set { Set(nameof(Text), ref _text, value); }
        }

        private void OkExecute() {
            if(!string.IsNullOrEmpty(Text)) {
                DialogResult = true;
            }
        }
    }
}
