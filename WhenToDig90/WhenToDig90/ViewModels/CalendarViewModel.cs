
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WhenToDig90.Data.Entities;
using WhenToDig90.Helpers;
using WhenToDig90.Messages;
using WhenToDig90.Services.Interfaces;
using WhenToDig90.Views;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class CalendarViewModel : ViewModelBase, IPageLifeCycleEvents
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IJobService _jobService;
        private string[] _months = new [] { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
        private IList<Job> _jobs;
        private Job _jobItemSelected;

        public CalendarViewModel(
            INavigationService navigationService, 
            IDialogService dialogService,
            IJobService jobService)
        {
            try
            {              
                if (navigationService == null) throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;

                if (jobService == null) throw new ArgumentNullException("jobService");
                _jobService = jobService;

                if (dialogService == null) throw new ArgumentNullException("dialogService");
                _dialogService = dialogService;
               // _dialogService.Initialize(new DialogPage());

                JobNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobPage); });
                ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
                PlantNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.PlantPage); });

                NewJobCommand = new RelayCommand(() => {
                    EntityEdit<Job> editMessage = new EntityEdit<Job>();
                    _navigationService.NavigateTo(Locator.JobEditPage);
                });
                EditJobCommand = new RelayCommand(() => {

                    EntityEdit<Job> editMessage = new EntityEdit<Job>();
                    editMessage.Value = _jobItemSelected.ID;
                    Messenger.Default.Send<EntityEdit<Job>>(editMessage);

                    _navigationService.NavigateTo(Locator.JobEditPage);
                });

                DeleteJobCommand = new RelayCommand<int>(async id => {
                    // await _dialogService.ShowMessage("My Message", "My Title");

                    await _dialogService.ShowMessage("Do you want to delete this job?", "Delete", "Ok", "Cancel", (result) =>
                     {
                         if (result)
                         {
                             _jobService.Delete(id);
                             GetJobsByMonth();
                             Messenger.Default.Send(new EntityAdded<Job>());
                             return;
                         }
                     });
                });

                

                _currentCallendarDate = DateTime.Now;

                //GetJobsByMonth();

                //DeleteAllJobs();
                              
             
            }catch(Exception ex)
            {
                Message = ex.Message;
                RaisePropertyChanged(() => Message);
            }
        }
        
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

        public IList<Job> Jobs
        {
            get { return _jobs; }
            set
            {
                _jobs = value;
                RaisePropertyChanged(() => Jobs);
            }
        }

        private DateTime _currentCallendarDate;
        public DateTime CurrentDate
        {
            get { return _currentCallendarDate; }
            set {
                _currentCallendarDate = value;               
                RaisePropertyChanged (() => CurrentMonthYear);

                GetJobsByMonth();
            }
        }

        public string CurrentMonthYear { get { return string.Format("{0} {1}",_months[_currentCallendarDate.Month - 1], _currentCallendarDate.Year); } }

        public ImageSource CalendarIcon{ get { return ImageSource.FromFile("calendar.png"); } }
        public ImageSource JobIcon{ get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon{ get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon{ get { return ImageSource.FromFile("plant_low.png"); } }

        public ICommand JobNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }
        public ICommand PlantNavigationCommand { get; set; }

        public ICommand NewJobCommand { get; set; }
        public ICommand EditJobCommand { get; set; }
        public ICommand DeleteJobCommand { get; set; }

        public Job JobItemSelected
        {
            get
            {
                return _jobItemSelected;
            }
            set
            {
                if (_jobItemSelected != value)
                {
                    _jobItemSelected = value;
                }
            }
        }

        public void OnAppearing()
        {
            GetJobsByMonth();
        }

        private void GetJobsByMonth()
        {
            _jobService.GetJobsByMonth((item, error) =>
            {
                if (error != null)
                {
                    Message = error.Message;
                    RaisePropertyChanged(() => Message);
                    return;
                }
                Jobs = item.Result;
                RaisePropertyChanged(() => Jobs);                

            }, _currentCallendarDate);
        }

        private void DeleteAllJobs()
        {
          
            foreach(var job in _jobs)
            {
                _jobService.Delete(job.ID);
            }
        }
    }
}
