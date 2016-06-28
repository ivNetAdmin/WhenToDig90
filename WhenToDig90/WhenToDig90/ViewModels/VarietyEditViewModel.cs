using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using WhenToDig90.Data.Entities;
using WhenToDig90.Messages;
using WhenToDig90.Services.Interfaces;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class VarietyEditViewModel : ViewModelBase, IPageLifeCycleEvents
    {
        private readonly INavigationService _navigationService;
        private readonly IPlantService _plantService;

        private static int _currentVarietyId;

        public VarietyEditViewModel(INavigationService navigationService, IPlantService plantService)
        {
            try
            {
                if (navigationService == null) throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;

                if (plantService == null) throw new ArgumentNullException("plantService");
                _plantService = plantService;

                SaveCommand = new RelayCommand(() =>
                {
                    Message = string.Empty;
                    RaisePropertyChanged(() => Message);

                    if (string.IsNullOrEmpty(Name))
                    {
                        Message = "You must enter a category name...";
                        RaisePropertyChanged(() => Message);
                    }
                    else
                    {
                        _plantService.SaveVariety(PlantName, _currentVarietyId, Name, PlantingNotes, HarvestingNotes);
                        PlantName = string.Empty;
                        _currentVarietyId = 0;
                        _navigationService.GoBack();
                    }
                });
                
                CancelCommand = new RelayCommand(() =>
                {
                    Message = string.Empty;
                    RaisePropertyChanged(() => Message);

                   // var currentPageIndex = Application.Current.MainPage.Navigation.NavigationStack.Count - 1;
                   // var currentPage = Application.Current.MainPage.Navigation.NavigationStack[currentPageIndex];
                   // Application.Current.MainPage.Navigation.RemovePage(currentPage);


                     _navigationService.GoBack();
                });

                SaveCommand = new RelayCommand(() =>
                {
                    Message = string.Empty;
                    RaisePropertyChanged(() => Message);

                    _navigationService.GoBack();
                });
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                RaisePropertyChanged(() => Message);
            }
        }

        private static string _plantName;
        public string PlantName
        {
            get { return _plantName; }
            set
            {
                _plantName = value;
                RaisePropertyChanged(() => PlantName);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _plantingNotes;
        public string PlantingNotes
        {
            get { return _plantingNotes; }
            set
            {
                _plantingNotes = value;
                RaisePropertyChanged(() => PlantingNotes);
            }
        }
        
        private string _harvestingNotes;
        public string HarvestingNotes
        {
            get { return _harvestingNotes; }
            set
            {
                _harvestingNotes = value;
                RaisePropertyChanged(() => HarvestingNotes);
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
    
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public static void ReceiveMessage(EntityEdit<Variety> message)
        {
            var ids = message.ValueList.Split(',');
            _plantName = ids[0];
            _currentVarietyId = Convert.ToInt32(ids[1]);
        }

        public void OnAppearing()
        {
            //throw new NotImplementedException();
        }
    }
}
