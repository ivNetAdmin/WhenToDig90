using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;

namespace WhenToDig90.ViewModels
{
    public class JobViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public JobViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            _navigationService = navigationService;

            NavigationCommand =
                new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage, Parameter ?? string.Empty); });
        }

        public ICommand NavigationCommand { get; set; }
        public string Parameter { get; set; }
    }
}
