
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Review;
        }
    }
}
