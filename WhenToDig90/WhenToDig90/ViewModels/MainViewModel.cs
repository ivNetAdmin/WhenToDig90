using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WhenToDig90.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
       private INavigationService navigationService;
       
       public RelayCommand CalendarCommand { get; set; }
       
       public MainViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
 
        CalendarCommand = new RelayCommand(() =>
        {
            navigationService.NavigateTo("Calendar", "My data");
        });
    }
    }
}
