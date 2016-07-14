using PropertyChanged;
using System;
using System.ComponentModel;

namespace SensorGUI.MVVM {
    [ImplementPropertyChanged]
    public class User {

        public event EventHandler<NameChangedEventArgs> NameChanged;
        public string Name { get; set; }
        public bool IsTriggerer { get; set; }
        public Guid Id { get; set; }
        public User() {
            this.Id = Guid.NewGuid();
        }

        public void ChangeName(string name) {
            Name = name;
            NameChanged?.Invoke(this, new NameChangedEventArgs { NewValue = name });
        }
    }

    public class NameChangedEventArgs : EventArgs {
        public string NewValue { get; set; }
    }
}