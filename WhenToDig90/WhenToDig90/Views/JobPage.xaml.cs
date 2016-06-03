
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

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //}
    }
}
