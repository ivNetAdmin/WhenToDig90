
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

            //Messenger.Default.Register<EntityEdit<Job>>(this, (message) =>
            //{
            //    ReceiveMessage(message);
            //});

            //TestDialogServiceCommand = new RelayCommand(async () => {
            //    await _dialogService.ShowMessage("hello mum", "Title");
            //});

            JobTypes = new[] { "Cultivate", "Sow", "Harvest" };
            JobType = "Cultivate";

            Plants = new[] { "Carrot", "Pea", "Bean" };

            JobDate = DateTime.Now;
            //var cakes = _currentJobId;

           // var currentJob = _jobService.Get(_currentJobId);
           //// this.Description = currentJob.Result.Description;

           // _description = currentJob.Result.Description;
           // RaisePropertyChanged(() => Description);

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

        //public string Description { get; set; }

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

        public string Notes { get; set; }

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

        //private string _errorMessage;
        //public string ErrorMessage
        //{
        //    get { return _errorMessage; }
        //    set
        //    {
        //        _errorMessage = value;
        //        RaisePropertyChanged(() => ErrorMessage);
        //    }
        //}
        
        internal static void ReceiveMessage(EntityEdit<Job> message)
        {

            //var job = _jobService.GetAll();

            //_description = message.Value.ToString();
            //RaisePropertyChanged(() => Description);
            _currentJobId = message.Value;
        }


        //private object ReceiveMessage(EntityEdit<Job> message)
        //{

        //    _description = message.Value.ToString();
        //    RaisePropertyChanged(() => Description);

        //    _currentJobId = message.Value;
        //    return null;
        //}

        public void OnAppearing()
        {
            try{
               var currentJob = _jobService.Get(_currentJobId).Result;
            // this.Description = currentJob.Result.Description;
            //if (currentJob != null)
            //{
                _description = currentJob.Description;
                RaisePropertyChanged(() => Description);
            //}
            }catch(Exception ex)
            {
                Message = ex.Message;
                RaisePropertyChanged(() => Message);
            }
        }
    }
}
