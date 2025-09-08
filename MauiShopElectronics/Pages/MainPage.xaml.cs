using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }
    }
}
