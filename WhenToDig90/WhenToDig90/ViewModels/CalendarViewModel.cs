
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WhenToDig90.Data.Entities;
using WhenToDig90.Messages;
using WhenToDig90.Services.Interfaces;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;
      //  private IMessenger _messengerInstance;
        private DateTime _currentCallendarDate;
        private string[] _months = new [] { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
        private IList<Job> _jobs;
        private Job _jobItemSelected;

        public CalendarViewModel(INavigationService navigationService, IJobService jobService)
        {
            try
            {              
                if (navigationService == null) throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;

                if (jobService == null) throw new ArgumentNullException("jobService");
                _jobService = jobService;

                JobNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobPage); });
                ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
                PlantNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.PlantPage); });

                NewJobCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobEditPage); });
                JobEditCommand = new RelayCommand(() => {

                    EntityEdit<Job> editMessage = new EntityEdit<Job>();
                    editMessage.Value = value.ID;
                    Messenger.Default.Send<EntityEdit<Job>>(editMessage);
                    
                });

                //JobListTappedGesture = new RelayCommand(() =>
                //{
                //    var cakes = "";
                //});

                //LoadedCommand = new RelayCommand(() => { var Cakes = ""; });

                _currentCallendarDate = DateTime.Now;

                //  MessengerInstance.Register<NotificationMessage<string>>(this, NotifyMe);               

                GetJobsByMonth();

                //DeleteAllJobs();
               
                //Messenger.Default.Register<GenericMessage<string>>(this, (message) =>
                //{
                //    GetJobsByMonth();
                //    RaisePropertyChanged(() => Jobs);
                //});

                Messenger.Default.Register<EntityAdded<Job>>(this, (message) =>
                {
                    GetJobsByMonth();
                    RaisePropertyChanged(() => Jobs);
                });

             
            }
            catch(Exception)
            {
                
            }
        }

        //private void NotifyMe(NotificationMessage<string> obj)
        //{
        //    var cakes = obj;
        //}

        public DateTime CurrentDate
        {
            get { return _currentCallendarDate; }
            set {
                _currentCallendarDate = value;               
                RaisePropertyChanged (() => CurrentMonthYear);

                GetJobsByMonth();
                RaisePropertyChanged(() => Jobs);
            }
        }

        //protected new IMessenger MessengerInstance
        //{
        //    get
        //    {
        //        return this._messengerInstance ?? Messenger.Default;
        //    }
        //    set
        //    {
        //        this._messengerInstance = value;
        //    }
        //}

        public string CurrentMonthYear { get { return string.Format("{0} {1}",_months[_currentCallendarDate.Month - 1], _currentCallendarDate.Year); } }
        public IList<Job> Jobs { get { return _jobs; } }        

        public ImageSource CalendarIcon{ get { return ImageSource.FromFile("calendar.png"); } }
        public ImageSource JobIcon{ get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon{ get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon{ get { return ImageSource.FromFile("plant_low.png"); } }
        
        public ICommand JobNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }
        public ICommand PlantNavigationCommand { get; set; }

        public ICommand NewJobCommand { get; set; }
        public ICommand JobEditCommand { get; set; }

        //public ICommand JobListTappedGesture { get; set; }
        //public ICommand LoadedCommand { get; set; }

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
                  //  EntityEdit<Job> editMessage = new EntityEdit<Job>();
                    //editMessage.Value = value.ID;
                    //Messenger.Default.Send<EntityEdit<Job>>(editMessage);

                    //_navigationService.NavigateTo(Locator.JobEditPage);
                  //  RaisePropertyChanged(() => JobItemSelected);
                }
            }
        }

        private void GetJobsByMonth()
        {
            _jobService.GetJobsByMonth((item, error) =>
            {
                if (error != null)
                {
                    return;
                }
                _jobs = item.Result;
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


//_jobService.GetAll((item, error) =>
//{
//    if (error != null)
//    {
//        return;
//    }
//    _jobs = item.Result;
//});
