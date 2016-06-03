
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Calendar;
            NavigationPage.SetHasBackButton(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var calendarGrid = this.FindByName<Grid>("CalendarGrid");
            calendarGrid.Children.Add(new Label { Text = "Hello mum" },0,0);
        }
    }
}
