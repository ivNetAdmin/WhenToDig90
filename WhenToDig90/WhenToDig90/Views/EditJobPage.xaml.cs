
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

            //var lifecycleHandler = (IPageLifeCycleEvents)this.BindingContext;
            //base.Appearing += (object sender, EventArgs e) => {
            //    lifecycleHandler.OnAppearing();
            //};
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
