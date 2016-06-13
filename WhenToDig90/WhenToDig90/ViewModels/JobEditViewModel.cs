
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
    public class JobEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;
        private string _message;
        //private IDialogService _dialogService;

        //private string _jobType;

        public JobEditViewModel(INavigationService navigationService, IJobService jobService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

            CancelCommand = new RelayCommand(() => {
                Message = string.Empty;
                _navigationService.GoBack();
            });

            SaveCommand = new RelayCommand(() =>
            {
                Message = string.Empty;

                if (string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(JobType))
                {
                    Message = "You must enter a job description...";
                }
                else
                {
                    _jobService.Save(JobDate, JobType, Description, PlantName, Notes);
                    //Messenger.Default.Send(new GenericMessage<string>("cakes"));
                    Messenger.Default.Send(new EntityAdded<Job>());
                    _navigationService.GoBack();
                }
            });

            //TestDialogServiceCommand = new RelayCommand(async () => {
            //    await _dialogService.ShowMessage("hello mum", "Title");
            //});

            JobTypes = new[] { "Cultivate", "Sow", "Harvest" };
            JobType = "Cultivate";

            Plants = new[] { "Carrot", "Pea", "Bean" };

            JobDate = DateTime.Now;

            Messenger.Default.Register<EntityEdit<Job>>(this, (message) =>
            {
                var cakes = "";
            });

            // MessengerInstance.Send<NotificationMessage>(new NotificationMessage("notification message"));
        }

        //public ICommand TestDialogServiceCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public string[] JobTypes { get; set; }

        public string[] Plants { get; set; }
        
        public string JobType { get; set; }

        //public string JobType
        //{
        //    get { return _jobType; }
        //    set
        //    {
        //        _jobType = value;
        //       // RaisePropertyChanged(() => JobType);
        //    }
        //}

        public DateTime JobDate { get; set; }

        public string PlantName { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }
     
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
