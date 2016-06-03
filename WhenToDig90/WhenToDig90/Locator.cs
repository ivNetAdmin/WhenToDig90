using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WhenToDig90.ViewModels;

namespace WhenToDig90
{
    public class Locator
    {
        /// <summary>
        /// Register all the used ViewModels, Services et. al. witht the IoC Container
        /// </summary>
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ViewModels
            SimpleIoc.Default.Register<CalendarViewModel>();
            SimpleIoc.Default.Register<JobViewModel>();
            SimpleIoc.Default.Register<ReviewViewModel>();
            SimpleIoc.Default.Register<PlantViewModel>();
        }

        public const string CalendarPage = "CalendarPage";
        public const string JobPage = "JobPage";
        public const string ReviewPage = "ReviewPage";
        public const string PlantPage = "PlantPage";

        /// <summary>
        /// Gets the Calendar property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CalendarViewModel Calendar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CalendarViewModel>();
            }
        }

        /// <summary>
        /// Gets the Job property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public JobViewModel Job
        {
            get
            {
                return ServiceLocator.Current.GetInstance<JobViewModel>();
            }
        }

        /// <summary>
        /// Gets the Review property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public PlantViewModel Plant
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlantViewModel>();
            }
        }
    }
}
