using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AzureFriday.Models;
using MvvmFiles.Services;

namespace MvvmFiles.ViewModels
{
    /// <summary>
    /// The main ViewModel that will be bound to MainView page.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Video> _videos;

        public List<Video> Videos
        {
            get { return _videos; }
            set {
                _videos = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            var employeesServices = new EmployeesServices();

            Videos = await employeesServices.GetVideosAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
