using MauiShopElectronics.ViewModels;
using Microsoft.Extensions.Configuration;

namespace MauiShopElectronics.Pages;

public partial class AdminPanelPage : ContentPage
{
	AdminViewModel viewModel;
	public AdminPanelPage(IConfiguration configuration)
	{
		InitializeComponent();
		viewModel = new AdminViewModel(configuration);
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.Apperaining();
    }
}