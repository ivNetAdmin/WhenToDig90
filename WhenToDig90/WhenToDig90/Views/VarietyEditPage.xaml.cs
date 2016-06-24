using WhenToDig90.ViewModels;
using Xamarin.Forms;


namespace WhenToDig90.Views
{
    public partial class VarietyEditPage : ContentPage
    {
        public VarietyEditPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.VarietyEdit;
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
