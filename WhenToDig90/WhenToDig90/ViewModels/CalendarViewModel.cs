
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WhenToDig90.Data.Entities;
using WhenToDig90.Services.Interfaces;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;
        private DateTime _currentCallendarDate;
        private string[] _months = new [] { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
        private Task<IList<Job>> _jobs;

        public CalendarViewModel(INavigationService navigationService, IJobService jobService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

            JobNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobPage); });
            ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
            PlantNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.PlantPage); });

            NewJobCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.EditJobPage); });
            EditJobCommand = new RelayCommand(() => { });

            _currentCallendarDate = DateTime.Now;

            _jobs = jobService.GetJobsByMonth(_currentCallendarDate);
      }

        public DateTime CurrentDate
        {
            get { return _currentCallendarDate; }
            set {
                _currentCallendarDate = value;
                _jobs = _jobService.GetJobsByMonth(_currentCallendarDate);
                RaisePropertyChanged (() => CurrentMonthYear);
            }
        }

        public string CurrentMonthYear { get { return string.Format("{0} {1}",_months[_currentCallendarDate.Month - 1], _currentCallendarDate.Year); } }
        public IList<Job> Jobs { get { return _jobs.Result; } }

        public ImageSource CalendarIcon{ get { return ImageSource.FromFile("calendar.png"); } }
        public ImageSource JobIcon{ get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon{ get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon{ get { return ImageSource.FromFile("plant_low.png"); } }
        
        public ICommand JobNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }
        public ICommand PlantNavigationCommand { get; set; }

        public ICommand NewJobCommand { get; set; }
        public ICommand EditJobCommand { get; set; }

        //public ICommand LastYearCommand { get; set; }
        //public ICommand LastMonthCommand { get; set; }
        //public ICommand NextMonthCommand { get; set; }
        //public ICommand NextYearCommand { get; set; }

    }
}
