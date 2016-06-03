using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Second;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = ServiceLocator.Current
                .GetInstance<INavigationService>()
                .CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);
        }
    }
}
