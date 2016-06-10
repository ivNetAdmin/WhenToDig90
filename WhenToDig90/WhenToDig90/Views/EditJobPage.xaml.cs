
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
    }
}
