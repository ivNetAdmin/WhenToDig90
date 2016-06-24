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
    public class VarietyEditViewModel : ViewModelBase, IPageLifeCycleEvents
    {
        private static int _currentPlantId;
        private static int _currentVarietyId;

        public VarietyEditViewModel()
        {
            try
            {
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
                        _plantService.SaveVariety(_currentPlantId, _currentVarietyId, Name, PlantingNotes, HarvestingNotes);
                        _currentPlantId = 0;
                        _currentVarietyId = 0;
                        _navigationService.GoBack();
                    }
                });
                
                CancelCommand = new RelayCommand(() =>
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
            _currentPlantId = Convert.ToInt32(ids[0]);
            _currentVarietyId = Convert.ToInt32(ids[1]);
        }

        public void OnAppearing()
        {
            //throw new NotImplementedException();
        }
    }
}
