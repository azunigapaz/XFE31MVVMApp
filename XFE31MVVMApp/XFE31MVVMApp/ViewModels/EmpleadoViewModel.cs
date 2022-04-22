using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFE31MVVMApp.Models;
using XFE31MVVMApp.Views;

namespace XFE31MVVMApp.ViewModels
{
    public class EmpleadoViewModel : BaseEmpleadoViewModel
    {
        public Command LoadEmpleadoCommand { get; }
        public ObservableCollection<EmpleadoInfo> EmpleadoInfos { get; }
        public Command AddEmpleadoCommand { get; }
        public Command EmpleadoTappedEdit { get; }
        public Command EmpleadoTappedDelete { get; }


        public EmpleadoViewModel(INavigation _navigation)
        {
            LoadEmpleadoCommand = new Command(async () => await ExecuteLoadEmpleadoCommand());
            EmpleadoInfos = new ObservableCollection<EmpleadoInfo>();
            AddEmpleadoCommand = new Command(OnAddEmpleado);
            EmpleadoTappedEdit = new Command<EmpleadoInfo>(OnEditEmpleado);
            EmpleadoTappedDelete = new Command<EmpleadoInfo>(OnDeleteEmpleado);
            Navigation = _navigation;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadEmpleadoCommand()
        {
            IsBusy = true;

            try
            {
                EmpleadoInfos.Clear();
                var empleadoList = await App.EmpleadoService.GetEmpleadosAsync();

                foreach (var emple in empleadoList)
                {
                    EmpleadoInfos.Add(emple);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddEmpleado(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddEmpleadoPage));

        }

        private async void OnEditEmpleado(EmpleadoInfo emple)
        {
            Navigation.PushAsync(new AddEmpleadoPage(emple));

        }

        private async void OnDeleteEmpleado(EmpleadoInfo emple)
        {
            if(emple == null)
            {
                return;
            }

            await App.EmpleadoService.DeteleEmpleadoAsync(emple.EmpledoId);
            await ExecuteLoadEmpleadoCommand();
        }
    }
}
