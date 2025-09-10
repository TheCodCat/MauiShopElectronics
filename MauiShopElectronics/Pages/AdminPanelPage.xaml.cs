using MauiShopElectronics.ViewModels;
using Microsoft.Extensions.Configuration;

namespace MauiShopElectronics.Pages;

public partial class AdminPanelPage : ContentPage
{
	AdminViewModel viewModel;
	public AdminPanelPage(IConfiguration configuration, IServiceProvider serviceProvider)
	{
		InitializeComponent();
		viewModel = new AdminViewModel(configuration, serviceProvider);
		BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		viewModel.Apperaining();
	}
}