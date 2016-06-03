
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
    
        public FirstViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            NavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.SecondPage); });
        }

        public ImageSource CalendarIcon{ get { return ImageSource.FromFile("calendar.png"); } }
        public ImageSource JobIcon{ get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon{ get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon{ get { return ImageSource.FromFile("plant_low.png"); } }
        
        public ICommand NavigationCommand { get; set; } 
    }
}
