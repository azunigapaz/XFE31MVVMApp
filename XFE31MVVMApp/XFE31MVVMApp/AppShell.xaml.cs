using System;
using System.Collections.Generic;
using XFE31MVVMApp.ViewModels;
using XFE31MVVMApp.Views;
using Xamarin.Forms;

namespace XFE31MVVMApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddEmpleadoPage), typeof(AddEmpleadoPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
