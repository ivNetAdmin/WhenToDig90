
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using WhenToDig90.Services.Interfaces;

namespace WhenToDig90.ViewModels
{
    public class JobEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;

        public JobEditViewModel(INavigationService navigationService, IJobService jobService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

            CancelCommand = new RelayCommand(() => { _navigationService.GoBack(); });

            SaveCommand = new RelayCommand(() =>
            {
                _jobService.Save(JobDate, JobType, Description, PlantName, Notes);
                Messenger.Default.Send(new GenericMessage<string>("cakes"));
                _navigationService.GoBack();
            });

            JobTypes = new[] { "Cultivate", "Sow", "Harvest" };

            Plants = new[] { "Carrot", "Pea", "Bean" };

            JobDate = DateTime.Now;

           // MessengerInstance.Send<NotificationMessage>(new NotificationMessage("notification message"));
        }

        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public string[] JobTypes { get; set; }

        public string[] Plants { get; set; }
        
        public string JobType { get; set; }

        public DateTime JobDate { get; set; }

        public string PlantName { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

    }
}
