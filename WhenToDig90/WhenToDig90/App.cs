using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhenToDig90.Data.Entities;
using WhenToDig90.Helpers;
using WhenToDig90.Messages;
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
            
            var ps = new PlantService();
            SimpleIoc.Default.Register<IPlantService>(() => ps);

            var ds = new DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => ds);

            var nav = new NavigationService();
            nav.Configure(Locator.CalendarPage, typeof(CalendarPage));
            nav.Configure(Locator.JobPage, typeof(JobPage));
            nav.Configure(Locator.ReviewPage, typeof(ReviewPage));
            nav.Configure(Locator.PlantPage, typeof(PlantPage));

            nav.Configure(Locator.JobEditPage, typeof(JobEditPage));
            nav.Configure(Locator.VarietyEditPage, typeof(VarietyEditPage));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            Messenger.Default.Register<EntityEdit<Job>>(this, (message) =>
            {
                JobEditViewModel.ReceiveMessage(message);
            });

            Messenger.Default.Register<EntityEdit<Plant>>(this, (message) =>
            {
                PlantViewModel.ReceiveMessage(message);
            });

            Messenger.Default.Register<EntityEdit<Variety>>(this, (message) =>
            {
                VarietyEditViewModel.ReceiveMessage(message);
            });
            
            var firstPage = new NavigationPage(new PlantPage());

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
