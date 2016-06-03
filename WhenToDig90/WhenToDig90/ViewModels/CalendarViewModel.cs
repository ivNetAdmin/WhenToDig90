
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using WhenToDig90.Services.Interfaces;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;
        private DateTime _currentCallendarDate;

        public CalendarViewModel(INavigationService navigationService, IJobService jobService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

            JobNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobPage); });
            ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
            PlantNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.PlantPage); });
            
            LastYearCommand = new RelayCommand(() => { CalendarNavOnButtonClicked("<<"); });
            LastMonthCommand = new RelayCommand(() => { CalendarNavOnButtonClicked("<"); });
            NextMonthCommand = new RelayCommand(() => { CalendarNavOnButtonClicked(">"); });
            NextYearCommand = new RelayCommand(() => { CalendarNavOnButtonClicked(">>"); });

            _currentCallendarDate = DateTime.Now;
        }

        public ImageSource CalendarIcon{ get { return ImageSource.FromFile("calendar.png"); } }
        public ImageSource JobIcon{ get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon{ get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon{ get { return ImageSource.FromFile("plant_low.png"); } }
        
        public ICommand JobNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }
        public ICommand PlantNavigationCommand { get; set; }

        public ICommand LastYearCommand { get; set; }
        public ICommand LastMonthCommand { get; set; }
        public ICommand NextMonthCommand { get; set; }
        public ICommand NextYearCommand { get; set; }

        public DateTime CurrentDate {
            get { return _currentCallendarDate; }
            set { _currentCallendarDate = value; }
        }

        private void CalendarNavOnButtonClicked(string action)
        {
            switch (action)
            {
                case "<<":
                    _currentCallendarDate = _currentCallendarDate.AddYears(-1);
                    break;
                case ">>":
                    _currentCallendarDate = _currentCallendarDate.AddYears(1);
                    break;
                case "<":
                    _currentCallendarDate = _currentCallendarDate.AddMonths(-1);
                    break;
                case ">":
                    _currentCallendarDate = _currentCallendarDate.AddMonths(1);
                    break;

            }

            //UpdateCalendar();
        }
    }
}
