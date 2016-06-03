
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class PlantPage : ContentPage
    {
        public PlantPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Plant;
        }
    }
}
