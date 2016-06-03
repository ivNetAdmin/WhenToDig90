using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using WhenToDig90.Views;

namespace WhenToDig90.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
          // ViewModels
            SimpleIoc.Default.Register<FirstViewModel>();
            SimpleIoc.Default.Register<SecondViewModel>();
            SimpleIoc.Default.Register<ThirdViewModel>();
        }

        public const string FirstPage = "FirstPage";
        public const string SecondPage = "SecondPage";
        public const string ThirdPage = "ThirdPage";
        
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FirstViewModel>();
            }
        }
    }

   /// <summary>
        /// Gets the Second property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SecondViewModel Second
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondViewModel>();
            }
        }

        /// <summary>
        /// Gets the third property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ThirdViewModel Third
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ThirdViewModel>();
            }
        }
   
}
