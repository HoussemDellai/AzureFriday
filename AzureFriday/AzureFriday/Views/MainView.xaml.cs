using AzureFriday.Models;
using MvvmFiles.ViewModels;
using Xamarin.Forms;

namespace AzureFriday.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new DetailsPage(e.Item as Video));
        }
    }
}
