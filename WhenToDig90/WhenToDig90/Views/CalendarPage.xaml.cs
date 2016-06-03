
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Calendar;
        }
    }
}
