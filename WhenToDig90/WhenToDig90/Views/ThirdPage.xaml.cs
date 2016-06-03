namespace WhenToDig90.Views
{
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage(string parameter)
        {
            InitializeComponent();
            var viewModel = App.Locator.Third;
            BindingContext = viewModel;

            viewModel.ParameterText = string.IsNullOrEmpty(parameter) ? "No parameter set" : parameter;
        }
    }
}
