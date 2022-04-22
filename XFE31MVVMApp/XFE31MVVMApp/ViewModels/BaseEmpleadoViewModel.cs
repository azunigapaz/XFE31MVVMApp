using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XFE31MVVMApp.Models;

namespace XFE31MVVMApp.ViewModels
{
    public class BaseEmpleadoViewModel:INotifyPropertyChanged
    {
        private EmpleadoInfo _empledoInfo;
        public INavigation Navigation { get; set; }

        public EmpleadoInfo EmpleadoInfo
        {
            get { return _empledoInfo; }
            set { _empledoInfo = value; OnPropertyChanged(); }
        }

        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }

        protected bool SetProperty<T>(ref T backIngStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backIngStore, value))
                return false;

            backIngStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
