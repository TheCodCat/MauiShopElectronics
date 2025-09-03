using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel viewModel;
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            mainViewModel._page = this;
            BindingContext = mainViewModel;
            viewModel = mainViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.Apperaining();
            viewModel._page = this;
        }
    }
}
