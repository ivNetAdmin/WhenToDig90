
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using WhenToDig90.Services.Interfaces;

namespace WhenToDig90.ViewModels
{
    public class EditJobViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IJobService _jobService;

        public EditJobViewModel(INavigationService navigationService, IJobService jobService)
        {          
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;
            
            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

           CancelCommand = new RelayCommand(() => { _navigationService.GoBack(); });

            ContactTypes = new[] { "Email", "Landline", "Mobile" };
        }

        public ICommand CancelCommand { get; set; }

        public string[] ContactTypes { get; set; }

    }
}
