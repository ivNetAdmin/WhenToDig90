
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage(string parameter)
        {
            InitializeComponent();
            BindingContext = App.Locator.Review;
        }
    }
}
