using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel viewModel;
        public MainPage(MainViewModel mainViewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
            viewModel = mainViewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Apperaining();
        }
    }
}
