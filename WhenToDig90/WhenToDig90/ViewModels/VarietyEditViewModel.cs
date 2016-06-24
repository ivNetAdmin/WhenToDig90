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
        private static int _currentVarietyId;

        public VarietyEditViewModel()
        {
            try
            {

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

        public static void ReceiveMessage(EntityEdit<Variety> message)
        {
            _currentVarietyId = message.Value;
        }

        public void OnAppearing()
        {
            //throw new NotImplementedException();
        }
    }
}
