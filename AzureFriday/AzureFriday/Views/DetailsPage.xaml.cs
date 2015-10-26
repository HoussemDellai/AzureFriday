using AzureFriday.Models;
using Xamarin.Forms;

namespace AzureFriday.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Video video)
        {
            InitializeComponent();

            BindingContext = video;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var link = LinksListView.SelectedItem as string;

            await Navigation.PushAsync(new VideoPlayerView());

            MessagingCenter.Send(link, "Hi", link);
        }
    }
}
