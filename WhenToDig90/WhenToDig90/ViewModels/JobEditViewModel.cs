
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
                    _jobService.Save(JobDate, JobType, Description, PlantName, Notes);
                    Messenger.Default.Send(new EntityAdded<Job>());
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
        
        public string JobType { get; set; }

        public DateTime JobDate { get; set; }

        public string PlantName { get; set; }

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

        internal static void ReceiveMessage(EntityEdit<Job> message)
        {
            _currentJobId = message.Value;
        }

        public void OnAppearing()
        {
            //try{
            var currentJob = _jobService.Get(_currentJobId).Result;
            if (currentJob != null)
            {
                Description = currentJob.Description;
                RaisePropertyChanged(() => Description);
            }
            //}catch(Exception ex)
            //{
            //    Message = ex.Message;
            //    RaisePropertyChanged(() => Message);
            //}
        }
    }
}
