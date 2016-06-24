using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WhenToDig90.Data.Entities;
using WhenToDig90.Messages;
using WhenToDig90.Services.Interfaces;
using WhenToDig90.Views;
using Xamarin.Forms;

namespace WhenToDig90.ViewModels
{
    public class PlantViewModel : ViewModelBase, IPageLifeCycleEvents
    {
        private readonly INavigationService _navigationService;
        private readonly IPlantService _plantService;
        private int _currentPlantId;

        public PlantViewModel(INavigationService navigationService, IPlantService plantService)
        {
            try{
                if (navigationService == null) throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;
                
                if (plantService == null) throw new ArgumentNullException("plantService");
                _plantService = plantService;

                Varieties = new List<Variety>();
                Varieties.Add(new Variety { Name = "New" });
                for (int i = 0; i < 10; i++)
                {
                    Varieties.Add(new Variety { Name = "Long Intermediate and fish" });
                }

                NewCommand = new RelayCommand(() =>
                {
                    Message = string.Empty;
                    _currentPlantId = 0;
                    Name = string.Empty;
                    Type = string.Empty;
                    Sow = string.Empty;
                    Harvest = string.Empty;
                    Notes = string.Empty;

                });

            SaveCommand = new RelayCommand(() =>
            {
                Message = string.Empty;
                RaisePropertyChanged(() => Message);

                if (string.IsNullOrEmpty(Name))
                {
                    Message = "You must enter a plant name...";
                    RaisePropertyChanged(() => Message);
                }
                else
                {
                    _plantService.Save(_currentPlantId, Name, Type, Sow, Harvest, Notes);
                    _currentPlantId = 0;
                    _navigationService.GoBack();
                }
            });
            
            CalendarNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.CalendarPage); });
            JobNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.JobPage); });
            ReviewNavigationCommand = new RelayCommand(() => { _navigationService.NavigateTo(Locator.ReviewPage); });
            }catch(Exception ex)
            {
                Message = ex.Message;
                RaisePropertyChanged(() => Message);
            }
        }

        public ImageSource CalendarIcon { get { return ImageSource.FromFile("calendar_low.png"); } }
        public ImageSource JobIcon { get { return ImageSource.FromFile("job_low.png"); } }
        public ImageSource ReviewIcon { get { return ImageSource.FromFile("review_low.png"); } }
        public ImageSource PlantIcon { get { return ImageSource.FromFile("plant.png"); } }

        public ICommand CalendarNavigationCommand { get; set; }
        public ICommand JobNavigationCommand { get; set; }
        public ICommand ReviewNavigationCommand { get; set; }

        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private List<string> _plants;
        public List<string> Plants
        {
            get { return _plants; }
            set
            {
                _plants = value;
                RaisePropertyChanged(() => Plants);
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

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged(() => Type);
            }
        }

        private string _sow;
        public string Sow
        {
            get { return _sow; }
            set
            {
                _sow = value;
                RaisePropertyChanged(() => Sow);
            }
        }

        private string _harvest;
        public string Harvest
        {
            get { return _harvest; }
            set
            {
                _harvest = value;
                RaisePropertyChanged(() => Harvest);
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged(() => Notes);
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

        private List<Variety> _varieties;
        public List<Variety> Varieties
        {
            get { return _varieties; }
            set
            {
                _varieties = value;
                RaisePropertyChanged(() => Varieties);
            }
        }

        private Variety _varietiy;
        public Variety VarietySelected
        {
            get { return _varietiy; }
            set
            {
                _varietiy = value;
                RaisePropertyChanged(() => VarietySelected);
            }
        }

        public void OnAppearing()
        {
            var currentPageIndex = Application.Current.MainPage.Navigation.NavigationStack.Count - 1;
            var varietyButtonGrid = Application.Current.MainPage.Navigation.NavigationStack[currentPageIndex].FindByName<Grid>("VarietyButtonGrid");

            var columnCounter = 0;
            var textColor = Color.White;

            foreach (Variety variety in _varieties)
            {
                var fontSize = variety.Name.Length > 12 
                    ? Device.GetNamedSize(NamedSize.Micro, typeof(Button)) 
                    : Device.GetNamedSize(NamedSize.Small, typeof(Button));

                if (columnCounter == 0)
                {
                    varietyButtonGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });                    
                }

                varietyButtonGrid.Children.Add(
                    new Button
                    {                       
                        Text = variety.Name,                       
                        TextColor = textColor,
                        FontSize = fontSize,
                        CommandParameter = variety.ID,
                        Command =  new RelayCommand<int>(id => {

                            EntityEdit<Variety> editMessage = new EntityEdit<Variety>();
                            editMessage.Value = id;
                            Messenger.Default.Send<EntityEdit<Variety>>(editMessage);

                            _navigationService.NavigateTo(Locator.EditVarietyPage);                        
                        })
                    }, columnCounter, varietyButtonGrid.RowDefinitions.Count-1);

                columnCounter++;

                    if (columnCounter == 3) columnCounter = 0;
                textColor = Color.Aqua;
            }        
        }
    }
}
