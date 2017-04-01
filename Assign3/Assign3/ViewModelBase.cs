using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//Code from Xamarin form samples Git Hub
namespace Assign3
    {
    public class ViewModelBase : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value,
                                      [CallerMemberName] string propertyName = null)
            {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
            }

        protected void OnPropertyChanged(string propertyName)
            {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                {
                handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }