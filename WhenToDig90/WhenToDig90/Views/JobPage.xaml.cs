using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;

using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class JobPage : ContentPage
    {
        public JobPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Job;
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