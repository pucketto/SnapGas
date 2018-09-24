using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnapGas.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            backingStore = value;
            onChanged?.Invoke();
            NotifyPropertyChanged(propertyName);

            return true;
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
