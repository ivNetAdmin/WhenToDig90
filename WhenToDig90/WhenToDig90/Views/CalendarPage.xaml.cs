
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class CalendarPage : ContentPage
    {
        private DateTime _currentCallendarDate;
        private string[] _weekDays;
        
        public CalendarPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            
            BindingContext = App.Locator.Calendar;
            
            _weekDays = new[] { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
            _currentCallendarDate = DateTime.Now;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BuildCalendar(calendarGrid);
        }
        
        private void BuildCalendar(Grid grid)
        {
            grid.VerticalOptions = LayoutOptions.Fill;
            
            var month = _currentCallendarDate.ToString("MMM yyyy");
            var fill = new int[] { 6, 0, 1, 2, 3, 4, 5 };
            
            var firstDayofMonth = new DateTime(_currentCallendarDate.Year, _currentCallendarDate.Month, 1).DayOfWeek;
            var calendarStartDate = new DateTime(_currentCallendarDate.Year, _currentCallendarDate.Month, 1)
                .AddDays(-1 * (fill[(int)firstDayofMonth]));

            var days = DateTime.DaysInMonth(_currentCallendarDate.Year, _currentCallendarDate.Month);

            var rowCount = days + fill[(int)firstDayofMonth] > 35 ? 6 : 5;

            var dates = new List<DateTime>();
            for (var d = 0; d < rowCount * 7; d++)
            {
                dates.Add(calendarStartDate.AddDays(d));
            }

            for (var r = 0; r < rowCount; r++)
            {
               // grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                BuildCalendarCells(grid, _weekDays, dates, r);
            }
        }
        
        private void BuildCalendarCells(
            Grid grid, string[] weekDays, 
            List<DateTime> dates, int r)
        {
            bool lowlight = r == 0 ? true : false;            
            for (var wd = 0; wd < weekDays.Length; wd++)
            {                               
                var dateIndex = (r) * weekDays.Length + wd;
                var dateStr = dateIndex < dates.Count ? Convert.ToString(dates[dateIndex].Day.ToString("D2")) : string.Empty;
                var today = ((DateTime)dates[dateIndex]).ToString("ddMMyyyy") == DateTime.Now.ToString("ddMMyyyy");
                //var taskImage = GetTaskImage(dates[dateIndex]);

                if (dateStr == "01")
                {
                    if (lowlight == true)
                    {
                        lowlight = false;
                    }
                    else
                    {
                        lowlight = true;
                    }
                }

                var relativeLayout = new RelativeLayout
                {
                    BackgroundColor = Color.Black
                };

                var backgroundImage = new Image()
                {
                //    Source = taskImage,
                    IsOpaque = true,
                    Opacity = 1.0,
                };

                var label = new Label
                {
                    Text = dateStr,
                    TextColor = lowlight == true ? Color.FromRgb(51, 51, 51) : today ? Color.Aqua : Color.Silver,
                    BackgroundColor = Color.Black//,
                };

                //label.GestureRecognizers.Add(new TapGestureRecognizer
                //{
                //    Command = new Command(() => OnLabelClicked(dates[dateIndex])),
                //});

                relativeLayout.Children.Add(
                    backgroundImage,
                    Constraint.Constant(0),
                    Constraint.Constant(0)
                );
                relativeLayout.Children.Add(

                label, Constraint.RelativeToParent((parent) => {
                    return parent.Width / 3;
                }),
                     Constraint.Constant(0));

                grid.Children.Add(relativeLayout, wd, r);
               
            }
        }
    }
}
