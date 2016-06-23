
using WhenToDig90.ViewModels;
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class PlantPage : ContentPage
    {
        public PlantPage()
        {
            InitializeComponent();            
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = App.Locator.Plant;
        }

        protected override void OnAppearing()
        {
            Context.OnAppearing();            
            base.OnAppearing();
        }

        private IPageLifeCycleEvents Context
        {
            get { return (IPageLifeCycleEvents)BindingContext; }
        }

    }
}
