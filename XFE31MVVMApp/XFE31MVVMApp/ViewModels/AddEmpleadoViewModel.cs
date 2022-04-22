using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFE31MVVMApp.Models;

namespace XFE31MVVMApp.ViewModels
{
    public class AddEmpleadoViewModel:BaseEmpleadoViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        
        public AddEmpleadoViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            EmpleadoInfo = new EmpleadoInfo();
        }  

        private async void OnSave()
        {
            var empleado = EmpleadoInfo;
            await App.EmpleadoService.AddEmpleadoAsync(empleado);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
