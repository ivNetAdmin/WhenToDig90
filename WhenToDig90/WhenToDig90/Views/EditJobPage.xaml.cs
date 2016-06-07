
using Xamarin.Forms;

namespace WhenToDig90.Views
{
    public partial class EditJobPage : ContentPage
    {
        public EditJobPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.EditJob;
        }
    }
}
