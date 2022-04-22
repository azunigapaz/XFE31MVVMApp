using System.ComponentModel;
using Xamarin.Forms;
using XFE31MVVMApp.ViewModels;

namespace XFE31MVVMApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}