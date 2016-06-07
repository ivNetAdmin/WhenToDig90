using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhenToDig90.Services;
using WhenToDig90.Services.Interfaces;
using WhenToDig90.ViewModels;
using WhenToDig90.Views;
using Xamarin.Forms;

namespace WhenToDig90
{
    public class App : Application
    {
       private static Locator _locator;
        public static Locator Locator { get { return _locator ?? (_locator = new Locator()); } }

        public App()
        {

            var js = new JobService();
            SimpleIoc.Default.Register<IJobService>(() => js);  

            var nav = new NavigationService();
            nav.Configure(Locator.CalendarPage, typeof(CalendarPage));
            nav.Configure(Locator.JobPage, typeof(JobPage));
            nav.Configure(Locator.ReviewPage, typeof(ReviewPage));
            nav.Configure(Locator.PlantPage, typeof(PlantPage));

            nav.Configure(Locator.EditJobPage, typeof(EditJobPage));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var firstPage = new NavigationPage(new CalendarPage());

            nav.Initialize(firstPage);

            MainPage = firstPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts  
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps  
        }
        protected override void OnResume()
        {
            // Handle when your app resumes  
        }
    }
}
