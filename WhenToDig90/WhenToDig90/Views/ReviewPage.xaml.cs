
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage(string parameter)
        {
            InitializeComponent();
            var viewModel = App.Locator.Review;
            BindingContext = viewModel;

            viewModel.ParameterText = string.IsNullOrEmpty(parameter) ? "No parameter set" : parameter;
        }
    }
}
