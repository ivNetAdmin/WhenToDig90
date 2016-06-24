
using System;
using WhenToDig90.ViewModels;
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class JobEditPage : ContentPage
    {        
        public JobEditPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.JobEdit;
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
