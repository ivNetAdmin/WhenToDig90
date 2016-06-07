
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using WhenToDig90.Services.Interfaces;

namespace WhenToDig90.ViewModels
{
    public class EditJobViewModel : ViewModelBase
    {
        private readonly IJobService _jobService;

        public EditJobViewModel(IJobService jobService)
        {          
            if (jobService == null) throw new ArgumentNullException("jobService");
            _jobService = jobService;

           CancelCommand = new RelayCommand(() => { });
        }

        public ICommand CancelCommand { get; set; }
    }
}
