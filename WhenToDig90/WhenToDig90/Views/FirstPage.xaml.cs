
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Main;
        }
    }
}
