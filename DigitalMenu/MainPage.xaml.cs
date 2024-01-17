using DigitalMenu.DataServices;
using DigitalMenu.ViewModel;

namespace DigitalMenu
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }

}
