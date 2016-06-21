
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using WhenToDig90.Data.Entities;
using WhenToDig90.Messages;
using WhenToDig90.Services.Interfaces;

namespace WhenToDig90.ViewModels
{
    public class JobEditViewModel : ViewModelBase, IPageLifeCycleEvents
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;
        private static int _currentJobId;
   
        public JobEditViewModel(INavigationService navigationService, IJobService jobService)
        {
            try{
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

            CancelCommand = new RelayCommand(() => {
                Message = string.Empty;
                _currentJobId = 0;
                _navigationService.GoBack();
            });

            SaveCommand = new RelayCommand(() =>
            {
                Message = string.Empty;
                RaisePropertyChanged(() => Message);

                if (string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(JobType))
                {
                    Message = "You must enter a job description...";
                    RaisePropertyChanged(() => Message);
                }
                else
                {
                    _jobService.Save(_currentJobId, JobDate, JobType, Description, PlantName, Notes);
                    _currentJobId = 0;
                    _navigationService.GoBack();
                }
            });

            JobTypes = new[] { "Cultivate", "Sow", "Harvest" };
            JobType = "Cultivate";

            Plants = new[] { "Carrot", "Pea", "Bean" };

            JobDate = DateTime.Now;
            
            }catch(Exception ex)
            {
                Message = ex.Message;
                RaisePropertyChanged(() => Message);
            }
        }
      
        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public string[] JobTypes { get; set; }

        public string[] Plants { get; set; }
        
        private string _jobType;
        public string JobType
        {
            get { return _jobType; }
            set
            {
                _jobType = value;
                RaisePropertyChanged(() => JobType);
            }
        }

        private DateTime _jobDate;
        public DateTime JobDate
        {
            get { return _jobDate; }
            set
            {
                _jobDate = value;
                RaisePropertyChanged(() => JobDate);
            }
        }

        private string _plantName;
        public string PlantName
        {
            get { return _plantName; }
            set
            {
                _plantName = value;
                RaisePropertyChanged(() => PlantName);
            }
        }


        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged(() => Notes);
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

        internal static void ReceiveMessage(EntityEdit<Job> message)
        {
            _currentJobId = message.Value;
        }

        public void OnAppearing()
        {          
            _jobService.Get((item, error) =>
            {
                if (error != null)
                {
                    Message = error.Message;
                    RaisePropertyChanged(() => Message);
                    return;
                }
                var currentJob = item.Result;

                if (currentJob != null)
                {
                    Description = currentJob.Description;
                    RaisePropertyChanged(() => Description);

                    PlantName = currentJob.Plant;
                    RaisePropertyChanged(() => PlantName);

                    JobType = currentJob.Type;
                    RaisePropertyChanged(() => JobType);

                    JobDate = currentJob.Date;
                    RaisePropertyChanged(() => JobDate);

                    Notes = currentJob.Notes;
                    RaisePropertyChanged(() => Notes);
                }else
                {
                    Description = string.Empty;
                    RaisePropertyChanged(() => Description);

                    PlantName = string.Empty;
                    RaisePropertyChanged(() => PlantName);

                    JobType = string.Empty;
                    RaisePropertyChanged(() => JobType);

                    JobDate = DateTime.Now;
                    RaisePropertyChanged(() => JobDate);

                    Notes = string.Empty;
                    RaisePropertyChanged(() => Notes);
                }

            }, _currentJobId);
        }
    }
}
