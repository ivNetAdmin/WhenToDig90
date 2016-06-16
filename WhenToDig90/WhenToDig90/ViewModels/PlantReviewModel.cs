using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class PlantViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public PlantViewModel(INavigationService navigationService)
        {
            try{
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            CalendarNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.CalendarPage); });
            JobNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobPage); });
            ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
            }catch(Exception ex)
            {
                Message = ex.Message;
                RaisePropertyChanged(() => Message);
            }
        }

        public ImageSource CalendarIcon { get { return ImageSource.FromFile("calendar_low.png"); } }
        public ImageSource JobIcon { get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon { get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon { get { return ImageSource.FromFile("plant.png"); } }

        public ICommand CalendarNavigationCommand { get; set; }
        public ICommand JobNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }
        
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }
    }
}
