using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamlStandardDemo.ViewModels;

namespace XamlStandardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}