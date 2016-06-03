using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class JobViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public JobViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            CalendarNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.CalendarPage); });
            ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
            PlantNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.PlantPage); });
        }

        public ImageSource CalendarIcon { get { return ImageSource.FromFile("calendar_low.png"); } }
        public ImageSource JobIcon { get { return ImageSource.FromFile("job.png"); } }
        public ImageSource ReviewIcon { get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon { get { return ImageSource.FromFile("plant_low.png"); } }

        public ICommand CalendarNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }
        public ICommand PlantNavigationCommand { get; set; }
    }
}
